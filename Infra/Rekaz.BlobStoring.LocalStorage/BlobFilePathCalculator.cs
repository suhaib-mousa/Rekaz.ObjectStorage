using Volo.Abp.DependencyInjection;

namespace Rekaz.BlobStoring.LocalStorage;

public class BlobFilePathCalculator : IBlobFilePathCalculator, ITransientDependency
{
    public virtual string Calculate(BlobProviderArgs args)
    {
        var fileSystemConfiguration = args.Configuration.GetLocalStorageConfiguration();
        var blobPath = fileSystemConfiguration.BasePath;

        blobPath = Path.Combine(blobPath, args.BlobName);

        return blobPath;
    }
}
