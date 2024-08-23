using Rekaz.BlobStoring.Database.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Rekaz.BlobStoring.Database.DatabaseBlobs;

public class EfCoreDatabaseBlobRepository : EfCoreRepository<DatabaseDbContext, DatabaseBlob, Guid>, IDatabaseBlobRepository
{
    public EfCoreDatabaseBlobRepository(IDbContextProvider<DatabaseDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
