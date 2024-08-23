using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rekaz.ObjectStorage.Data;
using Volo.Abp.DependencyInjection;

namespace Rekaz.ObjectStorage.EntityFrameworkCore;

public class EntityFrameworkCoreObjectStorageDbSchemaMigrator
    : IObjectStorageDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreObjectStorageDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ObjectStorageDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ObjectStorageDbContext>()
            .Database
            .MigrateAsync();
    }
}
