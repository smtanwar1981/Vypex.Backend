using Microsoft.EntityFrameworkCore;
using Vypex.Employee.Common.Models;
using Vypex.Employee.Common.Models.Entities;
using Vypex.Employee.Repositories.DataAccess.Configurations;

namespace Vypex.Employee.Repositories.DataAccess
{
    public class VypexEmployeeDbContext : DbContext
    {
        public VypexEmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<EmployeeEntity> Employees { get; set; }

        public virtual DbSet<EmployeeLeaveEntity> EmployeeLeaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DbConfigurations.EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DbConfigurations.EmployeeLeaveConfiguration());
        }
    }
}
