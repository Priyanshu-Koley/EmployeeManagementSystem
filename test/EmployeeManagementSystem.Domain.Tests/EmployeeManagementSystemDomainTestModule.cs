using Volo.Abp.Modularity;

namespace EmployeeManagementSystem;

[DependsOn(
    typeof(EmployeeManagementSystemDomainModule),
    typeof(EmployeeManagementSystemTestBaseModule)
)]
public class EmployeeManagementSystemDomainTestModule : AbpModule
{

}
