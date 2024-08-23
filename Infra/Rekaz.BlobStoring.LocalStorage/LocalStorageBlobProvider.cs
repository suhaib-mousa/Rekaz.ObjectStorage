using Polly;
using Volo.Abp.DependencyInjection;
using Volo.Abp.IO;

namespace Rekaz.BlobStoring.LocalStorage;

public class LocalStorageBlobProvider : BlobProviderBase, ITransientDependency
{
    private readonly IBlobFilePathCalculator _blobFilePathCalculator;

    public LocalStorageBlobProvider(IBlobFilePathCalculator blobFilePathCalculator)
    {
        _blobFilePathCalculator = blobFilePathCalculator;
    }
    public override async Task<Stream?> GetOrNullAsync(BlobProviderGetArgs args)
    {
        var filePath = _blobFilePathCalculator.Calculate(args);

        if (!File.Exists(filePath))
        {
            return null;
        }

        return await Policy.Handle<IOException>()
            .WaitAndRetryAsync(2, retryCount => TimeSpan.FromSeconds(retryCount))
            .ExecuteAsync(async () =>
            {
                using var fileStream = File.OpenRead(filePath);
                return await TryCopyToMemoryStreamAsync(fileStream, args.CancellationToken);
            });
    }

    public override async Task SaveAsync(BlobProviderSaveArgs args)
    {
        var filePath = _blobFilePathCalculator.Calculate(args);

        if (File.Exists(filePath))
        {
            throw new BlobAlreadyExistsException($"Saving BLOB '{args.BlobName}' does already exists!");
        }

        DirectoryHelper.CreateIfNotExists(Path.GetDirectoryName(filePath)!);

        await Policy.Handle<IOException>()
            .WaitAndRetryAsync(2, retryCount => TimeSpan.FromSeconds(retryCount))
            .ExecuteAsync(async () =>
            {
                using var fileStream = File.Open(filePath, FileMode.CreateNew, FileAccess.Write);
                await args.BlobStream.CopyToAsync(
                    fileStream,
                    args.CancellationToken
                );

                await fileStream.FlushAsync();
            });
    }
}