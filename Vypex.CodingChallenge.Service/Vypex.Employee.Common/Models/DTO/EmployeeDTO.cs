using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vypex.Employee.Common.Models.DTO
{
    public class EmployeeDTO
    {
        /// <summary>
        /// Gets or sets EmployeeId
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets EmployeeName
        /// </summary>
        public string EmployeeName { get; set; }
    }
}
