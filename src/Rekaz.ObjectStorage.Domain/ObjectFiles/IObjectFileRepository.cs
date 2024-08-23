using System;
using Volo.Abp.Domain.Repositories;

namespace Rekaz.ObjectStorage.ObjectFiles;

public interface IObjectFileRepository : IRepository<ObjectFile, Guid>
{
}
