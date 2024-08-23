using Volo.Abp.Modularity;

namespace Rekaz.BlobStoring.Database;

[DependsOn(
    typeof(DatabaseDomainModule),
    typeof(DatabaseTestBaseModule)
)]
public class DatabaseDomainTestModule : AbpModule
{

}
