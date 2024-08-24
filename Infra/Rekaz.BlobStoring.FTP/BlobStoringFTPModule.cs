using Volo.Abp.Modularity;

namespace Rekaz.BlobStoring.FTP;

[DependsOn(
    typeof(BlobStoringModule)
)]
public class BlobStoringFTPModule : AbpModule
{
}
