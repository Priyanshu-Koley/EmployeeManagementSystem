using EmployeeManagementSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EmployeeManagementSystem.Permissions;

public class EmployeeManagementSystemPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EmployeeManagementSystemPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(EmployeeManagementSystemPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EmployeeManagementSystemResource>(name);
    }
}
