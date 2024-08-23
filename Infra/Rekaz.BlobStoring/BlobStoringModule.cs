using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Rekaz.BlobStoring;

[DependsOn(
typeof(AbpThreadingModule)
)]
public class BlobStoringModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddTransient(
            typeof(IBlobStorageService),
            typeof(BlobStorageService)
        );
    }
}
