using EmployeeManagementSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EmployeeManagementSystem.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EmployeeManagementSystemEntityFrameworkCoreModule),
    typeof(EmployeeManagementSystemApplicationContractsModule)
    )]
public class EmployeeManagementSystemDbMigratorModule : AbpModule
{
}
