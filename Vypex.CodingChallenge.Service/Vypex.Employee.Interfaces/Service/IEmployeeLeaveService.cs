using Vypex.Employee.Common.Core;
using Vypex.Employee.Common.Models.DTO;
using Vypex.Employee.Common.Models.Entities;
using Vypex.Employee.Common.Models.Requests;

namespace Vypex.Employee.Interfaces.Service
{
    public interface IEmployeeLeaveService
    {
        /// <summary>
        /// Returns list of all employee leaves available in the database
        /// </summary>
        /// <returns></returns>
        Task<VypexServiceResult<IList<EmployeeLeaveDTO>>> GetEmployeeLeaves();

        /// <summary>
        /// Insert or Update employee leave
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<VypexServiceResult<EmployeeLeaveEntity>> UpsertEmployeeLeave(UpsertEmployeeLeaveRequest request);

        /// <summary>
        /// Delete an existing employee leave by leave id
        /// </summary>
        /// <param name="leaveId"></param>
        /// <returns></returns>
        Task<VypexServiceResult<int>> DeleteEmployeeLeave(Guid leaveId);
    }
}
