using Rekaz.ObjectStorage.Localization;
using Volo.Abp.Application.Services;

namespace Rekaz.ObjectStorage;

/* Inherit your application services from this class.
 */
public abstract class ObjectStorageAppService : ApplicationService
{
    protected ObjectStorageAppService()
    {
        LocalizationResource = typeof(ObjectStorageResource);
    }
}
