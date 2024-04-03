using EmployeeManagementSystem.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Account;
using Volo.Abp.Authorization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.Localization;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace EmployeeManagementSystem;

[DependsOn(
    typeof(EmployeeManagementSystemDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(EmployeeManagementSystemApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpAuthorizationModule)
    )]
public class EmployeeManagementSystemApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<EmployeeManagementSystemApplicationModule>();
        });
        // Add HR policy
        Configure<AuthorizationOptions>(options =>
        {
            options.AddPolicy("HRPolicy", policy =>
            {
                policy.RequireRole("HR");
            });
        });
    }
}
