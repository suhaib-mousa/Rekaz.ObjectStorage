using Volo.Abp.Modularity;

namespace Rekaz.BlobStoring.Database;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class DatabaseDomainTestBase<TStartupModule> : DatabaseTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
