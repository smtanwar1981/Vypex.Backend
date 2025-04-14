using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vypex.Employee.Common.Models.DTO
{
    public class EmployeeLeaveDTO
    {
        /// <summary>
        /// Gets or sets LeaveId
        /// </summary>
        public Guid LeaveId { get; set; }

        /// <summary>
        /// Gets or sets EmployeeId
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets StartDate of a leave
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets EndDate of a leave
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets CreatedOn date of a leave
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets UpdatedOn date of a leave
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets UpdatedBy as who updated the current leave record
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
