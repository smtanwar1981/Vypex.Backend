using Microsoft.EntityFrameworkCore;
using Vypex.Employee.Common.Models.Entities;
using Vypex.Employee.Common.Models.Requests;
using Vypex.Employee.Interfaces.Repository;
using Vypex.Employee.Repositories.DataAccess;

namespace Vypex.Employee.Repositories.Repository
{
    public class EmployeeLeaveRepository(VypexEmployeeDbContext _dbContext) : IEmployeeLeaveRepository
    {
        public IQueryable<EmployeeLeaveEntity> GetAllLeaves()
            => _dbContext.EmployeeLeaves.AsNoTracking();

        public async Task<EmployeeLeaveEntity> InsertLeave(EmployeeLeaveEntity leave)
        {
            _dbContext.EmployeeLeaves.Add(leave);
            await _dbContext.SaveChangesAsync();
            return leave;
        }

        public async Task<EmployeeLeaveEntity> UpdateLeave(EmployeeLeaveEntity leave)
        {
            _dbContext.EmployeeLeaves.Update(leave);
            await _dbContext.SaveChangesAsync();
            return leave;
        }

        public async Task<int> DeleteLeave(EmployeeLeaveEntity leave)
        {
            _dbContext.EmployeeLeaves.Remove(leave);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
