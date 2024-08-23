using JetBrains.Annotations;
using Volo.Abp;

namespace Rekaz.BlobStoring;

public class BlobProviderArgs
{
    [NotNull]
    public BlobStoringConfiguration Configuration { get; }

    [NotNull]
    public string BlobName { get; }

    public CancellationToken CancellationToken { get; }

    protected BlobProviderArgs(
        [NotNull] BlobStoringConfiguration configuration,
        [NotNull] string blobName,
        CancellationToken cancellationToken = default)
    {
        Configuration = Check.NotNull(configuration, nameof(configuration));
        BlobName = Check.NotNullOrWhiteSpace(blobName, nameof(blobName));
        CancellationToken = cancellationToken;
    }
}