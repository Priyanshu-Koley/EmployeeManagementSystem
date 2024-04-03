using EmployeeManagementSystem.Dtos;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace EmployeeManagementSystem.Services
{
    [Authorize("HRPolicy")]
    public class EmployeeService : CrudAppService<Employee,
            EmployeeDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateEmployeeDto,
            UpdateEmployeeDto
            >,
        IEmployeeService
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IAsyncQueryableExecuter _asyncExecuter;
        public EmployeeService(IRepository<Employee, Guid> employeeRepository, IAsyncQueryableExecuter asyncExecuter) :
            base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _asyncExecuter = asyncExecuter;
        }
        // Get employee list department wise
        public async Task<ListResultDto<EmployeeDto>> GetEmployeesByDepartmentAsync(string department)
        {
            IQueryable<Employee> queryable = await _employeeRepository.GetQueryableAsync();
            var query = queryable.Where(employee => employee.Department == department);

            var employees = await _asyncExecuter.ToListAsync(query);

            return new ListResultDto<EmployeeDto>(ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(employees));
        }
        // Search employees by name
        public async Task<ListResultDto<EmployeeDto>> GetEmployeesByNameAsync(string name)
        {

            var queryable = await _employeeRepository.GetQueryableAsync();

            var query = queryable
                .Where(e => e.Name.Contains(name));

            var employees = await _asyncExecuter.ToListAsync(query);

            return new ListResultDto<EmployeeDto>(ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(employees));
        }
    }
}
