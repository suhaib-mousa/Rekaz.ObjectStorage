using Volo.Abp.Modularity;

namespace Rekaz.BlobStoring.LocalStorage;

[DependsOn(
    typeof(BlobStoringModule)
    )]
public class BlobStoringLocalStorageModule : AbpModule
{
}
