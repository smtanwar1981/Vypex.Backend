using Vypex.Employee.Interfaces.Repository;
using Vypex.Employee.Interfaces.Service;
using Vypex.Employee.Repositories.Repository;
using Vypex.Employee.Services.Employee;
using Vypex.Employee.Services.Services;
using Vypex.Employee.WebApi.Services.Employee;

namespace Vypex.Employee.WebApi.Core.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
            => services
            .AddTransient<IEmployeeService, EmployeeService>()
            .AddTransient<IEmployeeLeaveService, EmployeeLeaveService>();
     
        public static IServiceCollection AddRepository(this IServiceCollection services)
            => services
            .AddTransient<IEmployeeRepository, EmployeeRepository>()
            .AddTransient<IEmployeeLeaveRepository, EmployeeLeaveRepository>();
    }
}
