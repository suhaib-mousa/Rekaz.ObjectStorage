using Rekaz.ObjectStorage.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Rekaz.ObjectStorage.ObjectFiles;

public class EfCoreObjectFileRepository : EfCoreRepository<ObjectStorageDbContext, ObjectFile, Guid>, IObjectFileRepository
{
    public EfCoreObjectFileRepository(IDbContextProvider<ObjectStorageDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
