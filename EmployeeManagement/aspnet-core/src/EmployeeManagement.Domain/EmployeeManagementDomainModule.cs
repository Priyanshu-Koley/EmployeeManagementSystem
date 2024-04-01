using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using EmployeeManagement.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.OpenIddict;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Microsoft.AspNetCore.Identity;
using System.Data;
using Volo.Abp;
using System.Threading.Tasks;
using System;
using Volo.Abp.Authorization.Permissions;
using EmployeeManagement.Localization;
using Volo.Abp.PermissionManagement;

namespace EmployeeManagement;

[DependsOn(
    typeof(EmployeeManagementDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpBackgroundJobsDomainModule),
    typeof(AbpFeatureManagementDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpOpenIddictDomainModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpTenantManagementDomainModule),
    typeof(AbpEmailingModule)
)]
public class EmployeeManagementDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية", "ae"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en", "en", "English", "gb"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("hr", "hr", "Croatian"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish", "fi"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français", "fr"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский", "ru"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak", "sk"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe", "tr"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español"));
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

        Configure<PermissionDefinitionContext>(options =>
        {
            var group = options.GetGroupOrNull("EmployeeManagement");
            if (group == null)
            {
                group = options.AddGroup("EmployeeManagement", L("EmployeeManagement"));
            }

            group.AddPermission("EmployeeManagement.Create", L("Create Employee"));
            group.AddPermission("EmployeeManagement.Edit", L("Edit Employee"));
            group.AddPermission("EmployeeManagement.Delete", L("Delete Employee"));
            group.AddPermission("EmployeeManagement.View", L("View Employee"));
        });

#if DEBUG
    context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
    public override async Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        var roleManager = context.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var roleExistsAdmin = await roleManager.RoleExistsAsync("ADMIN");
        Guid AdminId = new Guid();
        if (!roleExistsAdmin)
        {
            await roleManager.CreateAsync(new IdentityRole(AdminId, "ADMIN"));
        }

        var roleExistsHr = await roleManager.RoleExistsAsync("HR");
        Guid HrId = new Guid();
        if (!roleExistsHr)
        {
            await roleManager.CreateAsync(new IdentityRole(HrId, "HR"));
        }


        var permissionManager = context.ServiceProvider.GetRequiredService<IPermissionManager>();

        var hrRole = await roleManager.FindByNameAsync("HR");
        if (hrRole != null)
        {
            // Assign permissions to HR role
            await permissionManager.SetForRoleAsync(hrRole.Name, "EmployeeManagement.Create", true);
            await permissionManager.SetForRoleAsync(hrRole.Name, "EmployeeManagement.Edit", true);
            await permissionManager.SetForRoleAsync(hrRole.Name, "EmployeeManagement.Delete", true);
            await permissionManager.SetForRoleAsync(hrRole.Name, "EmployeeManagement.View", true);
        }
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EmployeeManagementResource>(name);
    }
}
