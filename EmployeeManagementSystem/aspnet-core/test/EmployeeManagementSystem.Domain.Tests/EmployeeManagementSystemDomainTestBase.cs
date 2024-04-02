using Volo.Abp.Modularity;

namespace EmployeeManagementSystem;

/* Inherit from this class for your domain layer tests. */
public abstract class EmployeeManagementSystemDomainTestBase<TStartupModule> : EmployeeManagementSystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
