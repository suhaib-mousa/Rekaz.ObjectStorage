using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Rekaz.BlobStoring.Database.DatabaseBlobs;

public class DatabaseBlob : AggregateRoot<Guid>
{
    public virtual byte[] Content { get; protected set; }
    public DatabaseBlob(Guid id, [NotNull] byte[] content) : base(id)
    {
        if (content.Length < 0)
        {
            throw new AbpException("Blob content size cannot be zero.");
        }
        Content = content;  
    }
}
