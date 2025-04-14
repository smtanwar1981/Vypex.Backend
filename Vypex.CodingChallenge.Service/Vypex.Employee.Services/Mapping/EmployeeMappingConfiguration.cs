using Mapster;
using Vypex.Employee.Common.Models.DTO;
using Vypex.Employee.Common.Models.Entities;

namespace Vypex.Employee.Services.Mapping
{
    public static class EmployeeMappingConfiguration
    {
        public static TypeAdapterConfig config = new TypeAdapterConfig();
        public static TypeAdapterConfig GetEmployeeDTO()
        {
            config.NewConfig<EmployeeEntity, EmployeeDTO>()
                    .Map(dest => dest.EmployeeId, src => src.Id)
                    .Map(dest => dest.EmployeeName, src => src.Name);
            return config;
        }

        public static TypeAdapterConfig GetEmployeeLeavesDTO()
        {
            config.NewConfig<EmployeeLeaveEntity, EmployeeLeaveDTO>()
                .Map(dest => dest.LeaveId, src => src.Id)
                .Map(dest => dest.EmployeeId, src => src.EmployeeId)
                .Map(dest => dest.StartDate, src => src.StartDate)
                .Map(dest => dest.EndDate, src => src.EndDate)
                .Map(dest => dest.CreatedOn, src => src.CreatedOn)
                .Map(dest => dest.UpdatedOn, src => src.UpdatedOn)
                .Map(dest => dest.UpdatedBy, src => src.UpdatedBy);
            return config;
        }
    }
}
