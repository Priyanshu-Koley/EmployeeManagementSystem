using EmployeeManagementSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EmployeeManagementSystem.ServiceInterface
{
    public interface IEmployeeService : ICrudAppService<
        EmployeeDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateEmployeeDto,
        UpdateEmployeeDto>
    {

        Task<ListResultDto<EmployeeDto>> GetEmployeesByDepartmentAsync(string department);
        Task<ListResultDto<EmployeeDto>> GetEmployeesByNameAsync(string name);

    }
}
