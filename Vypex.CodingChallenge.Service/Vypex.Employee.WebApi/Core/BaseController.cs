using Microsoft.AspNetCore.Mvc;
using Vypex.Employee.Common.Core;

namespace Vypex.Employee.WebApi.Core
{
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// A handler to reduce code redundancy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public IActionResult HandleServiceResult<T>(VypexServiceResult<T> result)
        {
            if (result.IsSuccess)
                return Ok(result.Value);
            else if (result.ErrorCode == 404)
                return NotFound(new { Message = result.ErrorMessage });
            else if (result.ErrorCode == 400)
                return BadRequest(new { Message = result.ErrorMessage });
            else if (result.ErrorCode == 500)
                return StatusCode(500, new { Message = result.ErrorMessage });
            else
                return StatusCode(500, new { Message = "An unexpected error occurred." });
        }
    }
}
