using AutoMapper;
using FyNxtEmployeeMgtApi.Models;
using FyNxtEmployeeMgtApi.Models.Dto;

namespace FyNxtEmployeeMgtApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDto,Employee>();
                config.CreateMap<Employee, EmployeeDto>();
                config.CreateMap<DepartmentDto, Department>();
                config.CreateMap<Department, DepartmentDto>();
            });
            return mappingConfig;
        }
    }
}
