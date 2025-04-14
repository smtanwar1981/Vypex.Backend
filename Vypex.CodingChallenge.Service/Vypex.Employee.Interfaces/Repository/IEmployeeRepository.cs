

using Vypex.Employee.Common.Models.Entities;

namespace Vypex.Employee.Interfaces.Repository
{
    public interface IEmployeeRepository
    {
        public IQueryable<EmployeeEntity> GetEmployees();
    }
}
