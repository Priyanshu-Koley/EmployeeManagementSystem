using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EmployeeManagement.Localization;
using Microsoft.AspNetCore.Authorization;
using Polly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;
using Volo.Abp.ObjectMapping;

namespace EmployeeManagement;

/* Inherit your application services from this class.
 */
public class EmployeeManagementAppService : ApplicationService
{

    private readonly IRepository<Employee, Guid> _employeeRepository;
    private readonly IAsyncQueryableExecuter _asyncExecuter;

    public EmployeeManagementAppService(IRepository<Employee, Guid> employeeRepository, IAsyncQueryableExecuter asyncExecuter)
    {
        _employeeRepository = employeeRepository;
        _asyncExecuter = asyncExecuter;


        LocalizationResource = typeof(EmployeeManagementResource);
    }

    //[Authorize(EmployeeManagementPermissions.HR.CreateEmployee)]
    public async Task<Employee> CreateEmployeeAsync(EmployeeDto input)
    {
        var employee = ObjectMapper.Map<EmployeeDto, Employee>(input);

        await _employeeRepository.InsertAsync(employee);

        return employee;
    }

    [Authorize(EmployeeManagementPermissions.HR.EditEmployee)]
    public async Task<Employee> UpdateEmployeeAsync(Guid id, EmployeeDto input)
    {
        var employee = await _employeeRepository.GetAsync(id);
        ObjectMapper.Map(input, employee);
        await _employeeRepository.UpdateAsync(employee);
        return employee;
    }

    [Authorize(EmployeeManagementPermissions.HR.DeleteEmployee)]
    public async Task DeleteEmployeeAsync(Guid id)
    {
        await _employeeRepository.DeleteAsync(id);
    }

    [Authorize(EmployeeManagementPermissions.HR.ViewEmployee)]
    public async Task<Employee> GetEmployeeAsync(Guid id)
    {
        var employee = await _employeeRepository.GetAsync(id);

        return (employee);
    }
    
    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        var employee = await _employeeRepository.ToListAsync();
        return employee;
    }

    public async Task<List<Employee>> GetEmployeesByDepartmentAsync(string department)
    {

        var queryable = await _employeeRepository.GetQueryableAsync();

        var query = queryable
            .Where(e => e.Department == department);

        List<Employee> employees = await _asyncExecuter.ToListAsync(query);

        return (employees);
    }
    
    public async Task<List<Employee>> GetEmployeesByNameAsync(string name)
    {

        var queryable = await _employeeRepository.GetQueryableAsync();

        var query = queryable
            .Where(e => e.Name.Contains(name));

        List<Employee> employees = await _asyncExecuter.ToListAsync(query);

        return (employees);
    }
}
