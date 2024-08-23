using Volo.Abp.Modularity;

namespace Rekaz.ObjectStorage;

[DependsOn(
    typeof(ObjectStorageDomainModule),
    typeof(ObjectStorageTestBaseModule)
)]
public class ObjectStorageDomainTestModule : AbpModule
{

}
