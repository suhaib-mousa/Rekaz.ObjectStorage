namespace Rekaz.BlobStoring.Database.DatabaseBlobs;

public static class DatabaseBlobProviderConfigurationExtensions
{
    public static BlobStoringConfiguration UseDatabase(
        this BlobStoringConfiguration configuration)
    {
        return configuration;
    }
}
