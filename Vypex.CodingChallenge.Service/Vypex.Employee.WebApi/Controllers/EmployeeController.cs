using Microsoft.AspNetCore.Mvc;
using Vypex.Employee.WebApi.Core;
using Vypex.Employee.WebApi.Services.Employee;

namespace Vypex.Employee.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController(IEmployeeService _empService) : BaseController
    {
        /// <summary>
        /// Endpoint to return list of Employees
        /// </summary>
        /// <returns>List<MEmployeeDTO></MEmployeeDTO></returns>

        [HttpGet("getEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await _empService.GetEmployees();
            return HandleServiceResult(result);

        }

        /// <summary>
        /// Endpoint to return Employee by EmployeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>EmployeeDTO</returns>
        [HttpGet("getEmployeeById")]
        public async Task<IActionResult> GetEmployeeByEmployeeId(Guid employeeId)
        {
            var result = await _empService.GetEmployeeByEmployeeId(employeeId);
            return HandleServiceResult(result);
        }

        /// <summary>
        /// Endpoint to return Employees with their Leaves data
        /// </summary>
        /// <returns>EmployeesWithLeavesDTO</returns>
        [HttpGet("getEmployeesWithLeaves")]
        public async Task<IActionResult> GetEmployeesWithLeaves()
        {
            var result = await _empService.GetEmployeesWithLeaves(string.Empty);
            return HandleServiceResult(result);
        }

        /// <summary>
        /// Endpoint to return Employees with their Leaves data
        /// </summary>
        /// <returns>EmployeesWithLeavesDTO</returns>
        [HttpGet("getEmployeesByName/{searchTerm}")]
        public async Task<IActionResult> GetEmployeesByName(string searchTerm)
        {
            var result = await _empService.GetEmployeesWithLeaves(searchTerm);
            return HandleServiceResult(result);
        }
    }
}
