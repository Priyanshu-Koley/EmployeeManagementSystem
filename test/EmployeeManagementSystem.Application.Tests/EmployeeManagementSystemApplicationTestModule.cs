using Volo.Abp.Modularity;

namespace EmployeeManagementSystem;

[DependsOn(
    typeof(EmployeeManagementSystemApplicationModule),
    typeof(EmployeeManagementSystemDomainTestModule)
)]
public class EmployeeManagementSystemApplicationTestModule : AbpModule
{

}
