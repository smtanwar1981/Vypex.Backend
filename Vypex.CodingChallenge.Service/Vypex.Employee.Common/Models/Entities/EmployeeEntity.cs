using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vypex.Employee.Common.Models.Entities
{
    public class EmployeeEntity
    {
        /// <summary>
        /// Gets or sets Id for an employee
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Name of an employee
        /// </summary>
        public string Name { get; set; }
    }
}
