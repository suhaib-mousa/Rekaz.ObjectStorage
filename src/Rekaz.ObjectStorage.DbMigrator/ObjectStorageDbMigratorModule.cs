using Rekaz.ObjectStorage.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Rekaz.ObjectStorage.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ObjectStorageEntityFrameworkCoreModule),
    typeof(ObjectStorageApplicationContractsModule)
)]
public class ObjectStorageDbMigratorModule : AbpModule
{
}
