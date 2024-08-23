using JetBrains.Annotations;
using System;
using Volo.Abp.Application.Dtos;

namespace Rekaz.ObjectStorage.ObjectFiles;

public class ObjectFileDto : EntityDto<Guid>
{
    [NotNull]
    public string Data { get; set; }
    public int Size { get; set; }
    public DateTime CreatedAt { get; set; }
}