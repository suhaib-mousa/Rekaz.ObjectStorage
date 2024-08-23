using System.Threading.Tasks;

namespace Rekaz.ObjectStorage.Data;

public interface IObjectStorageDbSchemaMigrator
{
    Task MigrateAsync();
}
