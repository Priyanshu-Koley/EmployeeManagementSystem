using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagementSystem.Data;
using Volo.Abp.DependencyInjection;

namespace EmployeeManagementSystem.EntityFrameworkCore;

public class EntityFrameworkCoreEmployeeManagementSystemDbSchemaMigrator
    : IEmployeeManagementSystemDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreEmployeeManagementSystemDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the EmployeeManagementSystemDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<EmployeeManagementSystemDbContext>()
            .Database
            .MigrateAsync();
    }
}
