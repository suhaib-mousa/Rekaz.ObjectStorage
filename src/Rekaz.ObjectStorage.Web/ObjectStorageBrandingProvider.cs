using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Rekaz.ObjectStorage.Web;

[Dependency(ReplaceServices = true)]
public class ObjectStorageBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ObjectStorage";
}
