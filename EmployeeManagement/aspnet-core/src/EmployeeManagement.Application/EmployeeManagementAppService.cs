using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Localization;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;

namespace EmployeeManagement;

/* Inherit your application services from this class.
 */
public abstract class EmployeeManagementAppService : ApplicationService
{
    protected EmployeeManagementAppService()
    {
        LocalizationResource = typeof(EmployeeManagementResource);
    }


}
