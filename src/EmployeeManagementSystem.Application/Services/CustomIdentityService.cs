using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Authorization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace EmployeeManagementSystem.Services
{
    [Dependency(ReplaceServices = true)]
    public class CustomIdentityService : IdentityUserAppService
    {
        private readonly ICurrentUser _currentUser;
        public CustomIdentityService(
            IdentityUserManager userManager,
            IIdentityUserRepository userRepository,
            IIdentityRoleRepository roleRepository,
            IOptions<IdentityOptions> options,
            ICurrentUser currentUser

        ) : base(
            userManager,
            userRepository,
            roleRepository,
             options
            )
        {
            _currentUser = currentUser;
        }
        public override async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            var isAdmin = _currentUser.IsInRole("admin");
            var isInputRoleHr = input.RoleNames.Any(x => x != "HR");
            if (isAdmin == true && isInputRoleHr == false)
            {

                return await base.CreateAsync(input);
            }
            else
            {
                throw new AbpAuthorizationException("Not Authorized: Admin can create HR only");
            }

        }
        public override async Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
        {
            var isAdmin = _currentUser.IsInRole("admin");
            var isInputRoleHr = input.RoleNames.Any(x => x != "HR");
            if (isAdmin == true && isInputRoleHr == false)
            {

                return await base.UpdateAsync(id, input);
            }
            else
            {
                throw new AbpAuthorizationException("Not Authorized: Admin can create user of HR only");
            }

        }
    }

}

