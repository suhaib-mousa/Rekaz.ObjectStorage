namespace Rekaz.BlobStoring;

public interface IBlobStorageService
{
    Task SaveAsync(
        string name,
        Stream stream,
        CancellationToken cancellationToken = default
    );
    Task<Stream> GetAsync(
         string name,
         CancellationToken cancellationToken = default
     );
}
