using Volo.Abp.Modularity;

namespace Rekaz.BlobStoring.Aws;

[DependsOn(typeof(BlobStoringModule))]
public class BlobStoringAwsModule : AbpModule
{
}
