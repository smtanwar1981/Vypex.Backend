namespace Vypex.Employee.Common.Models.DTO
{
    public class EmployeesWithLeavesDTO
    {
        /// <summary>
        /// Gets or sets EmployeeId
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets EmployeeName
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets EmployeeLeaves
        /// </summary>
        public IList<EmployeeLeaveDTO> EmployeeLeaves { get; set; }

        /// <summary>
        /// Gets or sets TotalLeaves
        /// </summary>
        public int NumberOfDays { get; set; }

        /// <summary>
        /// Gets or sets LeavesCount
        /// </summary>
        public int LeavesCount { get; set; }
    }
}
