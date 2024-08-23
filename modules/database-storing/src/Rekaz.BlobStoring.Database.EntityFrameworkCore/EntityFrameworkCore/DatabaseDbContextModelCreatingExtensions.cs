using Microsoft.EntityFrameworkCore;
using Rekaz.BlobStoring.Database.DatabaseBlobs;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Rekaz.BlobStoring.Database.EntityFrameworkCore;

public static class DatabaseDbContextModelCreatingExtensions
{
    public static void ConfigureDatabase(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));


        builder.Entity<DatabaseBlob>(b =>
        {
            b.ToTable(DatabaseDbProperties.DbTablePrefix + "Blobs", DatabaseDbProperties.DbSchema);
            b.ConfigureByConvention();
        });
    }
}
