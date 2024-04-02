using EmployeeManagementSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EmployeeManagementSystemController : AbpControllerBase
{
    protected EmployeeManagementSystemController()
    {
        LocalizationResource = typeof(EmployeeManagementSystemResource);
    }
}
