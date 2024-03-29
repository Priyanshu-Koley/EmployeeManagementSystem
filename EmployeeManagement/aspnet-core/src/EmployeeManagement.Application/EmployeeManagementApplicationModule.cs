using EmployeeManagement.Permissions;
using System.Text.RegularExpressions;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace EmployeeManagement;

[DependsOn(
    typeof(EmployeeManagementDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(EmployeeManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class EmployeeManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<EmployeeManagementApplicationModule>();
        });

        //Configure<AbpIdentityOptions>(options =>
        //{
        //    options.RoleManagement.StaticRoles.Add(
        //        new IdentityRoleConfiguration
        //        {
        //            RoleName = "HR",
        //            GrantedPermissions = new[] { "EmployeeManagement.Admin.CreateHR" }
        //        }
        //    );
        //});

        //Configure<PermissionManagementOptions>(options =>
        //{
        //    options.AddGroup("ADMIN", group =>
        //    {
        //        group.AddPermission(MyProjectNamePermissions.AdminRole_AddUserToAdmin, L("Permission:AdminRole.AddUserToAdmin"));
        //        // Add other permissions to this group as needed
        //    });
        //});

    }


}
