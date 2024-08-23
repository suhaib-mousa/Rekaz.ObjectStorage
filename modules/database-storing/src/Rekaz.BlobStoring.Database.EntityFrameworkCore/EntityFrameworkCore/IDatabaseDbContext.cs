﻿using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Rekaz.BlobStoring.Database.EntityFrameworkCore;

[ConnectionStringName(DatabaseDbProperties.ConnectionStringName)]
public interface IDatabaseDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
