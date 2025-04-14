using Microsoft.AspNetCore.Mvc;
using Vypex.Employee.Common.Models.Requests;
using Vypex.Employee.Interfaces.Service;
using Vypex.Employee.WebApi.Core;

namespace Vypex.Employee.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeLeaveController(IEmployeeLeaveService _empLeaveService, ILogger<EmployeeLeaveController> _logger) : BaseController
    {

        /// <summary>
        /// Endpoint to return Employee Leaves
        /// </summary>
        /// <returns>EmployeeLeaveDTO</returns>
        [HttpGet("getEmployeeLeaves")]
        public async Task<IActionResult> GetEmployeeLeaves()
        {
            _logger.LogInformation($"Begin executing {nameof(GetEmployeeLeaves)}");

            var result = await _empLeaveService.GetEmployeeLeaves();

            _logger.LogInformation($"Finish executing {nameof(GetEmployeeLeaves)}");

            return HandleServiceResult(result);
        }

        /// <summary>
        /// Endpoint to add Employee Leave
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("upsertLeave")]
        public async Task<IActionResult> UpsertEmployeeLeave(UpsertEmployeeLeaveRequest request)
        {
            _logger.LogInformation($"Begin executing {nameof(UpsertEmployeeLeave)}");

            var result = await _empLeaveService.UpsertEmployeeLeave(request);

            _logger.LogInformation($"Finish executing {nameof(UpsertEmployeeLeave)}");

            return HandleServiceResult(result);
        }

        /// <summary>
        /// Endpoint to delete an existing Employee Leave
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteLeave/{leaveId}")]
        public async Task<IActionResult> DeleteEmployeeLeave(Guid leaveId)
        {
            _logger.LogInformation($"Begin executing {nameof(DeleteEmployeeLeave)}");

            var result = await _empLeaveService.DeleteEmployeeLeave(leaveId);

            _logger.LogInformation($"Finish executing {nameof(DeleteEmployeeLeave)}");

            return HandleServiceResult(result);
        }
    }
}
