using Rekaz.ObjectStorage.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Rekaz.ObjectStorage.Web.Pages;

public abstract class ObjectStoragePageModel : AbpPageModel
{
    protected ObjectStoragePageModel()
    {
        LocalizationResourceType = typeof(ObjectStorageResource);
    }
}
