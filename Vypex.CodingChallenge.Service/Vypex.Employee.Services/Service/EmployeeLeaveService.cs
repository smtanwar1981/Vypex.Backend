using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.Employee.Common.Core;
using Vypex.Employee.Common.Models.DTO;
using Vypex.Employee.Common.Models.Entities;
using Vypex.Employee.Common.Models.Requests;
using Vypex.Employee.Interfaces.Repository;
using Vypex.Employee.Interfaces.Service;
using Vypex.Employee.Services.Mapping;

namespace Vypex.Employee.Services.Services
{
    public class EmployeeLeaveService(IEmployeeLeaveRepository _empLeaveRepo) : IEmployeeLeaveService
    {
        /// <inheritdoc />
        public async Task<VypexServiceResult<IList<EmployeeLeaveDTO>>> GetEmployeeLeaves()
        {
            var empLeaves = _empLeaveRepo.GetAllLeaves();

            if (empLeaves == null)
                return VypexServiceResult<IList<EmployeeLeaveDTO>>.Failure($"An error occurred while reading database", 500);

            if (empLeaves.Count() < 1)
                return VypexServiceResult<IList<EmployeeLeaveDTO>>.Failure($"No employee leave found in the database", 400);

            var result = (await empLeaves.ToListAsync()).Adapt<IList<EmployeeLeaveDTO>>(EmployeeMappingConfiguration.GetEmployeeLeavesDTO());
            return VypexServiceResult<IList<EmployeeLeaveDTO>>.Success(result);

        }

        /// <inheritdoc />
        public async Task<VypexServiceResult<EmployeeLeaveEntity>> UpsertEmployeeLeave(UpsertEmployeeLeaveRequest request)
        {
            if (request == null)
                return Failure("Request is empty");

            if (request.EmployeeId == Guid.Empty)
                return Failure($"No employee ID in the request - {request.EmployeeId}");

            if (string.IsNullOrEmpty(request.StartDate) || string.IsNullOrEmpty(request.EndDate))
                return Failure("Start Date and End Date are mandatory");

            if (!IsValidDate(request.StartDate) || !IsValidDate(request.EndDate))
                return Failure("Either Start Date or End Date is invalid");

            var parsedStartDate = DateTime.Parse(request.StartDate);
            var parsedEndDate = DateTime.Parse(request.EndDate);

            if (parsedStartDate >= parsedEndDate)
                return Failure("Start Date cannot be greater than or equal to End Date");

            var leaves = _empLeaveRepo.GetAllLeaves();

            if (leaves == null)
                return Failure("An error occurred while reading from the database", 500);

            bool isLeaveExist = leaves.Any(l => l.Id == request.EmployeeLeaveId);

            var employeeLeaves = !isLeaveExist ? leaves.Where(l => l.EmployeeId == request.EmployeeId).ToList() : leaves.Where(l => l.Id == request.EmployeeLeaveId).ToList();

            if (!isLeaveExist)
            {
                foreach (var employeeLeave in employeeLeaves)
                {
                    if (IsOverlapping(employeeLeave, parsedStartDate, parsedEndDate))
                        return Failure($"Existing leave from {employeeLeave.StartDate} to {employeeLeave.EndDate} overlaps with new leave period", 400);
                }
            }

            var existingEntity = !isLeaveExist ? null : leaves.FirstOrDefault(l => l.Id == request.EmployeeLeaveId);

            var entity = new EmployeeLeaveEntity
            {
                Id = request.EmployeeLeaveId,
                EmployeeId = request.EmployeeId,
                StartDate = parsedStartDate,
                EndDate = parsedEndDate,
                CreatedOn = !isLeaveExist ? DateTime.UtcNow : existingEntity?.CreatedOn ?? DateTime.UtcNow,
                UpdatedBy = request.UpdatedBy,
                UpdatedOn = DateTime.UtcNow
            };

            var result = !isLeaveExist ? await _empLeaveRepo.InsertLeave(entity) : await _empLeaveRepo.UpdateLeave(entity);
            return VypexServiceResult<EmployeeLeaveEntity>.Success(result);
        }

        /// <inheritdoc />
        public async Task<VypexServiceResult<int>> DeleteEmployeeLeave(Guid leaveId)
        {
            var empLeaves = _empLeaveRepo.GetAllLeaves();

            if (empLeaves == null)
                return VypexServiceResult<int>.Failure($"An error occurred while reading database", 500);

            var leaveToDelete = await empLeaves.FirstOrDefaultAsync(l => l.Id == leaveId);

            if(leaveToDelete == null)
                return VypexServiceResult<int>.Failure($"No employee leave found with this leave id - {leaveId}", 500);

            var result = await _empLeaveRepo.DeleteLeave(leaveToDelete);
            return VypexServiceResult<int>.Success(result);
        }


        private VypexServiceResult<EmployeeLeaveEntity> Failure(string message, int statusCode = 400)
            => VypexServiceResult<EmployeeLeaveEntity>.Failure(message, statusCode);

        private bool IsOverlapping(EmployeeLeaveEntity existing, DateTime newStart, DateTime newEnd)
            => existing.StartDate < newEnd && newStart < existing.EndDate;

        private bool IsValidDate(string dateString)
            => DateTime.TryParse(dateString, out _);
    }
}
