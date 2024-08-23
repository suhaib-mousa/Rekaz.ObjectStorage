namespace Rekaz.BlobStoring;

public interface IBlobProvider
{
    Task SaveAsync(BlobProviderSaveArgs args);

    Task<Stream?> GetOrNullAsync(BlobProviderGetArgs args);
}