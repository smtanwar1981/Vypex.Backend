using Vypex.Employee.Common.Core;
using Vypex.Employee.Common.Models.DTO;

namespace Vypex.Employee.WebApi.Services.Employee
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Returns list of employee available in the database
        /// </summary>
        /// <returns></returns>
        Task<VypexServiceResult<IList<EmployeeDTO>>> GetEmployees();

        /// <summary>
        /// Returns an employee by employee id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<VypexServiceResult<EmployeeDTO>> GetEmployeeByEmployeeId(Guid employeeId);

        /// <summary>
        /// Returns filtered list of employees if searchTerm has value
        /// </summary>
        /// <returns></returns>
        Task<VypexServiceResult<List<EmployeesWithLeavesDTO>>> GetEmployeesWithLeaves(string searchTerm);
    }
}
