using Volo.Abp.DependencyInjection;

namespace Rekaz.BlobStoring.Aws;

public class AwsBlobProvider : BlobProviderBase, ITransientDependency
{
    public override Task<Stream?> GetOrNullAsync(BlobProviderGetArgs args)
    {
        throw new NotImplementedException();
    }

    public async override Task SaveAsync(BlobProviderSaveArgs args)
    {
        throw new NotImplementedException();
    }

    private async Task<IDisposable> GetAmazonS3Client(BlobProviderSaveArgs args)
    {
        throw new NotImplementedException();
    }
}
