using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace EmployeeManagementSystem
{
    public class EmployeeManagementSystemDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IdentityRoleManager _roleRepository;
        public EmployeeManagementSystemDataSeedContributor(IdentityRoleManager roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // Seed HR role
            var hrRole = await _roleRepository.FindByNameAsync("HR");
            if (hrRole == null)
            {
                hrRole = new IdentityRole(Guid.NewGuid(), "HR");
                await _roleRepository.CreateAsync(hrRole);
            }
        }
    }
}
