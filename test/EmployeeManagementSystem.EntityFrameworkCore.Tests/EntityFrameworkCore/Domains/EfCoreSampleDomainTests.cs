using EmployeeManagementSystem.Samples;
using Xunit;

namespace EmployeeManagementSystem.EntityFrameworkCore.Domains;

[Collection(EmployeeManagementSystemTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<EmployeeManagementSystemEntityFrameworkCoreTestModule>
{

}
