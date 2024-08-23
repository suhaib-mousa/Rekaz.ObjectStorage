using Rekaz.ObjectStorage.Samples;
using Xunit;

namespace Rekaz.ObjectStorage.EntityFrameworkCore.Domains;

[Collection(ObjectStorageTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ObjectStorageEntityFrameworkCoreTestModule>
{

}
