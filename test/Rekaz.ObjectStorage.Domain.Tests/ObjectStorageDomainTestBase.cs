using Volo.Abp.Modularity;

namespace Rekaz.ObjectStorage;

/* Inherit from this class for your domain layer tests. */
public abstract class ObjectStorageDomainTestBase<TStartupModule> : ObjectStorageTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
