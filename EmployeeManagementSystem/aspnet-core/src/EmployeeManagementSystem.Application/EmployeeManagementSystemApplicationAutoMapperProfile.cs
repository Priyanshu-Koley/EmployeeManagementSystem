using AutoMapper;
using EmployeeManagementSystem.Dtos;
using EmployeeManagementSystem.Entities;

namespace EmployeeManagementSystem;

public class EmployeeManagementSystemApplicationAutoMapperProfile : Profile
{
    public EmployeeManagementSystemApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<UpdateEmployeeDto, Employee>();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
    }
}
