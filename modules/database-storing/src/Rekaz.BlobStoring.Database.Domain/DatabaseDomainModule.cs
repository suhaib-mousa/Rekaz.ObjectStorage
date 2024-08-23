using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Rekaz.BlobStoring.Database;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(DatabaseDomainSharedModule)
)]
public class DatabaseDomainModule : AbpModule
{

}
