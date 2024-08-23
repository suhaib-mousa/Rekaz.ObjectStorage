using Rekaz.ObjectStorage.Samples;
using Xunit;

namespace Rekaz.ObjectStorage.EntityFrameworkCore.Applications;

[Collection(ObjectStorageTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ObjectStorageEntityFrameworkCoreTestModule>
{

}
