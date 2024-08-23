using JetBrains.Annotations;
using System;

namespace Rekaz.ObjectStorage.ObjectFiles;

public class ObjectFileInput
{
    [NotNull]
    public Guid Id { get; set; }
    [NotNull]
    public string Data { get; set; }
}