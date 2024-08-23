
namespace Rekaz.BlobStoring;

public abstract class BlobProviderBase : IBlobProvider
{
    public abstract Task<Stream?> GetOrNullAsync(BlobProviderGetArgs args);

    public abstract Task SaveAsync(BlobProviderSaveArgs args);

    protected virtual async Task<Stream?> TryCopyToMemoryStreamAsync(Stream? stream, CancellationToken cancellationToken = default)
    {
        if (stream == null)
        {
            return null;
        }

        var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream, cancellationToken);
        memoryStream.Seek(0, SeekOrigin.Begin);
        return memoryStream;
    }
}
