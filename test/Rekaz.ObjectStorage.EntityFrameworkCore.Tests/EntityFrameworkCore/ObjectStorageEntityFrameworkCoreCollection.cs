using Xunit;

namespace Rekaz.ObjectStorage.EntityFrameworkCore;

[CollectionDefinition(ObjectStorageTestConsts.CollectionDefinitionName)]
public class ObjectStorageEntityFrameworkCoreCollection : ICollectionFixture<ObjectStorageEntityFrameworkCoreFixture>
{

}
