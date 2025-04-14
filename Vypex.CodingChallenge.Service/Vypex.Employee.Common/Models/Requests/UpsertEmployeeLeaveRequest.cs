using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vypex.Employee.Common.Models.Requests
{
    public class UpsertEmployeeLeaveRequest
    {
        /// <summary>
        /// Gets or sets EmployeeLeaveId
        /// </summary>
        public Guid EmployeeLeaveId { get; set; }

        /// <summary>
        /// Gets or sets EmployeeId
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets StartDate
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets EndDate
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets UpdatedBy
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
