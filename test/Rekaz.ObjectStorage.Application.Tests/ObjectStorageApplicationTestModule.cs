using Volo.Abp.Modularity;

namespace Rekaz.ObjectStorage;

[DependsOn(
    typeof(ObjectStorageApplicationModule),
    typeof(ObjectStorageDomainTestModule)
)]
public class ObjectStorageApplicationTestModule : AbpModule
{

}
