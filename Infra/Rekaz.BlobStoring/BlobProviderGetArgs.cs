using JetBrains.Annotations;

namespace Rekaz.BlobStoring;

public class BlobProviderGetArgs : BlobProviderArgs
{
    public BlobProviderGetArgs(
        [NotNull] BlobStoringConfiguration configuration,
        [NotNull] string blobName,
        CancellationToken cancellationToken = default)
        : base(
            configuration,
            blobName,
            cancellationToken)
    {
    }
}