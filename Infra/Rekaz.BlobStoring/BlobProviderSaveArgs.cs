using JetBrains.Annotations;
using Volo.Abp;

namespace Rekaz.BlobStoring;

public class BlobProviderSaveArgs : BlobProviderArgs
{
    [NotNull]
    public Stream BlobStream { get; }
    public BlobProviderSaveArgs(
       [NotNull] BlobStoringConfiguration configuration,
       [NotNull] string blobName,
       [NotNull] Stream blobStream,
       CancellationToken cancellationToken = default)
        : base(
       configuration,
       blobName,
       cancellationToken)
    {
        BlobStream = Check.NotNull(blobStream, nameof(blobStream));
    }
}