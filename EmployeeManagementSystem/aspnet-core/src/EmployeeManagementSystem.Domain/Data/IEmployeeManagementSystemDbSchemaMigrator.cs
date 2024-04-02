using System.Threading.Tasks;

namespace EmployeeManagementSystem.Data;

public interface IEmployeeManagementSystemDbSchemaMigrator
{
    Task MigrateAsync();
}
