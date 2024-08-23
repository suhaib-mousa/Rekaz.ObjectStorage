using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Rekaz.ObjectStorage.Data;

/* This is used if database provider does't define
 * IObjectStorageDbSchemaMigrator implementation.
 */
public class NullObjectStorageDbSchemaMigrator : IObjectStorageDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
