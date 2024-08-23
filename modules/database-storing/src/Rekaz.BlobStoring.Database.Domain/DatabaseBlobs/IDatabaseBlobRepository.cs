using System;
using Volo.Abp.Domain.Repositories;

namespace Rekaz.BlobStoring.Database.DatabaseBlobs;

public interface IDatabaseBlobRepository : IRepository<DatabaseBlob, Guid>
{
}