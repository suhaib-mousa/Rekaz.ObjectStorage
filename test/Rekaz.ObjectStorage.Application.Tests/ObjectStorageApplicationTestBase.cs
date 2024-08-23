using Volo.Abp.Modularity;

namespace Rekaz.ObjectStorage;

public abstract class ObjectStorageApplicationTestBase<TStartupModule> : ObjectStorageTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
