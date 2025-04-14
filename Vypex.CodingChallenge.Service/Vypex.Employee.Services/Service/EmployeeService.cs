using Mapster;
using Microsoft.EntityFrameworkCore;
using Vypex.Employee.Common.Core;
using Vypex.Employee.Common.Models.DTO;
using Vypex.Employee.Interfaces.Repository;
using Vypex.Employee.Interfaces.Service;
using Vypex.Employee.Services.Mapping;
using Vypex.Employee.WebApi.Services.Employee;

namespace Vypex.Employee.Services.Employee
{
    public class EmployeeService(IEmployeeRepository _empRepo, IEmployeeLeaveService _empLeaveService) : IEmployeeService
    {
        /// <inheritdoc />
        public async Task<VypexServiceResult<IList<EmployeeDTO>>> GetEmployees()
        {
            var employees = _empRepo.GetEmployees();

            if (employees == null)
                return VypexServiceResult<IList<EmployeeDTO>>.Failure($"An error occurred while reading database", 500);
            
            if (employees.Count() < 1)
                return VypexServiceResult<IList<EmployeeDTO>>.Failure($"No employee found in the database", 400);
            
            var result = (await employees.ToListAsync()).Adapt<IList<EmployeeDTO>>(EmployeeMappingConfiguration.GetEmployeeDTO());
            return VypexServiceResult<IList<EmployeeDTO>>.Success(result);
        }

        /// <inheritdoc />
        public async Task<VypexServiceResult<EmployeeDTO>> GetEmployeeByEmployeeId(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
            {
                return VypexServiceResult<EmployeeDTO>.Failure($"Bad Request: Empty EmployeeId", 400);
            }

            var employee = await _empRepo.GetEmployees().Where(emp => emp.Id == employeeId).FirstOrDefaultAsync();

            if (employee == null)
            {
                return VypexServiceResult<EmployeeDTO>.Failure($"No employee found with this EmployeeId", 404);
            }
            var result = employee.Adapt<EmployeeDTO>(EmployeeMappingConfiguration.GetEmployeeDTO());
            return VypexServiceResult<EmployeeDTO>.Success(result);
        }

        public async Task<VypexServiceResult<List<EmployeesWithLeavesDTO>>> GetEmployeesWithLeaves(string searchTerm)
        {
            var employees = await _empRepo.GetEmployees().ToListAsync();
            var empLeaves = await _empLeaveService.GetEmployeeLeaves();

            if (employees == null)
                return VypexServiceResult<List<EmployeesWithLeavesDTO>>.Failure($"An error occurred while reading employees table", 500);

            if (employees.Count() < 1)
                return VypexServiceResult< List<EmployeesWithLeavesDTO>>.Failure($"No employee found in the database", 400);

            if(empLeaves == null)
                return VypexServiceResult<List<EmployeesWithLeavesDTO>>.Failure($"An error occurred while reading employee leaves table", 500);

            if (!string.IsNullOrEmpty(searchTerm))
                employees = employees.Where(emp => emp.Name.ToLower().Contains(searchTerm.ToLower())).ToList();

            var employeesWithLeaves = new List<EmployeesWithLeavesDTO>();
            foreach (var employee in employees)
            {
                var leaves = empLeaves.Value.Where(el => el.EmployeeId == employee.Id).Adapt<IList<EmployeeLeaveDTO>>(EmployeeMappingConfiguration.GetEmployeeLeavesDTO());
                var employeeWithLeaves = new EmployeesWithLeavesDTO
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name,
                    EmployeeLeaves = leaves,
                    NumberOfDays = CalculatLeaveCount(leaves),
                    LeavesCount = leaves.Count()
                };
                employeesWithLeaves.Add(employeeWithLeaves);
            }

            return VypexServiceResult<List<EmployeesWithLeavesDTO>>.Success(employeesWithLeaves);
        }

        private int CalculatLeaveCount(IList<EmployeeLeaveDTO> leaves)
        {
            var totalLeaves = 0; 
            foreach (var leave in leaves)
            {
                TimeSpan duration = (leave.EndDate - leave.StartDate);
                totalLeaves = totalLeaves + (int)duration.TotalDays;
            }
            return totalLeaves;
        }
    }    
}
