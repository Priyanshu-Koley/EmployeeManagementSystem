using EmployeeManagementSystem.Samples;
using Xunit;

namespace EmployeeManagementSystem.EntityFrameworkCore.Applications;

[Collection(EmployeeManagementSystemTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<EmployeeManagementSystemEntityFrameworkCoreTestModule>
{

}
