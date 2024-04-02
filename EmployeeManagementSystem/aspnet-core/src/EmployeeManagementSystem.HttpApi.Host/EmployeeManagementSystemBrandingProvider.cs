using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EmployeeManagementSystem;

[Dependency(ReplaceServices = true)]
public class EmployeeManagementSystemBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EmployeeManagementSystem";
}
