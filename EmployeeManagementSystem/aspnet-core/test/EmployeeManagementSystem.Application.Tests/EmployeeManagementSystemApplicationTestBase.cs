using Volo.Abp.Modularity;

namespace EmployeeManagementSystem;

public abstract class EmployeeManagementSystemApplicationTestBase<TStartupModule> : EmployeeManagementSystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
