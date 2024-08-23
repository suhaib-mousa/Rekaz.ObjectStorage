using Microsoft.Extensions.DependencyInjection;
using Rekaz.BlobStoring.Database.DatabaseBlobs;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rekaz.BlobStoring.Database.EntityFrameworkCore;

[DependsOn(
    typeof(DatabaseDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class DatabaseEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<DatabaseDbContext>(options =>
        {
            options.AddRepository<DatabaseBlob, EfCoreDatabaseBlobRepository>();
        });
    }
}
