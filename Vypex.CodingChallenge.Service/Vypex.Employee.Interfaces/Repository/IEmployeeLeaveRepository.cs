using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vypex.Employee.Common.Models;
using Vypex.Employee.Common.Models.Entities;

namespace Vypex.Employee.Interfaces.Repository
{
    public interface IEmployeeLeaveRepository
    {
        IQueryable<EmployeeLeaveEntity> GetAllLeaves();

        Task<EmployeeLeaveEntity> InsertLeave(EmployeeLeaveEntity leave);

        Task<EmployeeLeaveEntity> UpdateLeave(EmployeeLeaveEntity leave);

        Task<int> DeleteLeave(EmployeeLeaveEntity leave);
    }
}
