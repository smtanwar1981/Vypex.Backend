using Microsoft.EntityFrameworkCore;
using Vypex.Employee.Common.Models.Entities;
using Vypex.Employee.Interfaces.Repository;
using Vypex.Employee.Repositories.DataAccess;

namespace Vypex.Employee.Repositories.Repository
{
    public class EmployeeRepository(VypexEmployeeDbContext _dbContext) : IEmployeeRepository
    {
        public IQueryable<EmployeeEntity> GetEmployees()
            => _dbContext.Employees.AsNoTracking();
        
    }
}
