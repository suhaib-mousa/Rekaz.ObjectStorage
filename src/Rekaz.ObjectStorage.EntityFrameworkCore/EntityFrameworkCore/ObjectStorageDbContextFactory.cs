using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Rekaz.ObjectStorage.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ObjectStorageDbContextFactory : IDesignTimeDbContextFactory<ObjectStorageDbContext>
{
    public ObjectStorageDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        ObjectStorageEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<ObjectStorageDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new ObjectStorageDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Rekaz.ObjectStorage.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
