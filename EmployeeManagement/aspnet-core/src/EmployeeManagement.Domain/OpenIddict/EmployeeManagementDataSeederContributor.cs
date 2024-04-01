using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace EmployeeManagement.OpenIddict
{
    public class EmployeeManagementDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IdentityUserManager _userManager;
        private readonly IdentityRoleManager _roleRepository;
        public EmployeeManagementDataSeederContributor(IdentityUserManager userManager, IdentityRoleManager roleRepository)
        {
            _userManager = userManager;
            _roleRepository = roleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // Seed admin role
            var adminRole = await _roleRepository.FindByNameAsync("ADMIN");
            if (adminRole == null)
            {
                adminRole = new IdentityRole(Guid.NewGuid(), "ADMIN");
                await _roleRepository.CreateAsync(adminRole);
            }

            // Seed HR role
            var hrRole = await _roleRepository.FindByNameAsync("HR");
            if (hrRole == null)
            {
                hrRole = new IdentityRole(Guid.NewGuid(), "HR");
                await _roleRepository.CreateAsync(hrRole);
            }


            // Seed admin user
            var adminUser = await _userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                adminUser = new IdentityUser(Guid.NewGuid(), "admin", "admin@example.com");
                await _userManager.CreateAsync(adminUser, "admin@123"); // Set password here
            }

            // Assign admin role to admin user
            await _userManager.AddToRoleAsync(adminUser, "ADMIN");

            // Seed HR user
            var hrUser = await _userManager.FindByNameAsync("hr");
            if (hrUser == null)
            {
                hrUser = new IdentityUser(Guid.NewGuid(), "hr", "hruser@example.com");
                await _userManager.CreateAsync(hrUser, "hr@123"); // Set password here
            }

            // Assign HR role to HR user
            await _userManager.AddToRoleAsync(hrUser, "HR");
        }
    }
}
