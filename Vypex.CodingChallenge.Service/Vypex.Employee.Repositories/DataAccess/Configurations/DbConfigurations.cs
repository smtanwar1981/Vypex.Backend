using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vypex.Employee.Common.Models.Entities;

namespace Vypex.Employee.Repositories.DataAccess.Configurations
{
    public class DbConfigurations
    {
        public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
        {
            public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
            {
                builder.ToTable("Employee");
                builder.Property(e => e.Id).HasColumnName("Id");
                builder.Property(e => e.Name).HasColumnName("Name");
            }
        }

        public class EmployeeLeaveConfiguration : IEntityTypeConfiguration<EmployeeLeaveEntity>
        {
            public void Configure(EntityTypeBuilder<EmployeeLeaveEntity> builder)
            {
                builder.ToTable("EmployeeLeave");
                builder.Property(e => e.Id).HasColumnName("Id");
                builder.Property(e => e.EmployeeId).HasColumnName("EmployeeId");
                builder.Property(e => e.StartDate).HasColumnName("StartDate");
                builder.Property(e => e.EndDate).HasColumnName("EndDate");
                builder.Property(e => e.CreatedOn).HasColumnName("CreatedOn");
                builder.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn");
                builder.Property(e => e.UpdatedBy).HasColumnName("UpdatedBy");
            }
        }
    }
}
