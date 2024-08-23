using Rekaz.ObjectStorage.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Rekaz.ObjectStorage.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ObjectStorageController : AbpControllerBase
{
    protected ObjectStorageController()
    {
        LocalizationResource = typeof(ObjectStorageResource);
    }
}
