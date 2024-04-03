using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EmployeeManagementSystem.Data;

/* This is used if database provider does't define
 * IEmployeeManagementSystemDbSchemaMigrator implementation.
 */
public class NullEmployeeManagementSystemDbSchemaMigrator : IEmployeeManagementSystemDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
