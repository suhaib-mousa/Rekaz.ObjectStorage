using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Threading;

namespace Rekaz.BlobStoring;

public class BlobStorageService : IBlobStorageService
{

    protected BlobStoringConfiguration _configuration { get; }

    protected IBlobProvider _provider { get; }

    protected ICancellationTokenProvider _cancellationTokenProvider { get; }


    public BlobStorageService(
        IBlobProvider provider,
        ICancellationTokenProvider cancellationTokenProvider,
        IServiceProvider serviceProvider,
        IOptions<BlobStoringOptions> options)
    {
        _configuration = options.Value.Configuration;
        _provider = provider;
        _cancellationTokenProvider = cancellationTokenProvider;
    }

    public virtual async Task<Stream> GetAsync(string name, CancellationToken cancellationToken = default)
    {
        var stream = await _provider.GetOrNullAsync(
                new BlobProviderGetArgs(
                    _configuration,
                    name!,
                    _cancellationTokenProvider.FallbackToProvider(cancellationToken)
                )
            );

        if (stream == null)
        {
            throw new AbpException(
                $"Could not find the requested BLOB '{name}'!");
        }

        return stream;
    }

    public virtual async Task SaveAsync(string name, Stream stream, CancellationToken cancellationToken = default)
    {
        await _provider.SaveAsync(
            new BlobProviderSaveArgs(
                _configuration,
                name!,
                stream,
                _cancellationTokenProvider.FallbackToProvider(cancellationToken)
            )
        );
    }
}