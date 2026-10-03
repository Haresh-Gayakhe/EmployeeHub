using AutoMapper;
using EmployeeHub.Entities.DTOs.Department;
using EmployeeHub.Entities.Models;

namespace EmployeeHub.Business.Mappings
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();
            CreateMap<Department, DepartmentResponseDto>();
        }
    }
}
