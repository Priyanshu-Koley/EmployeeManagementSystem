using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Localization;
using EmployeeManagementSystem.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace EmployeeManagementSystem;

/* Inherit your application services from this class.
 */
public abstract class EmployeeManagementSystemAppService : ApplicationService
{
    protected EmployeeManagementSystemAppService()
    {
        LocalizationResource = typeof(EmployeeManagementSystemResource);
    }
}
