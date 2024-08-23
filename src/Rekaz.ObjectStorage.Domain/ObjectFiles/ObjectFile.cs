using JetBrains.Annotations;
using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Rekaz.ObjectStorage.ObjectFiles;

public class ObjectFile : Entity<Guid>, IHasCreationTime
{
    public ObjectFile(
        [NotNull] Guid id,
        int size)
    {
        if (size < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size cannot be negative.");
        }

        Id = id;
        Size = size;
        CreationTime = DateTime.UtcNow;
    }
    public int Size { get; set; }
    public DateTime CreationTime {  get; set; }
}
