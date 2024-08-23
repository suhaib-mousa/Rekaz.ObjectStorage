namespace Rekaz.BlobStoring.LocalStorage;

public static class LocalStorageBlobProviderConfigurationExtensions
{
    public static LocalStorageBlobProviderConfiguration GetFileSystemConfiguration(
        this BlobStoringConfiguration configuration)
    {
        return new LocalStorageBlobProviderConfiguration(configuration);
    }

    public static BlobStoringConfiguration UseFileSystem(
        this BlobStoringConfiguration configuration,
        Action<LocalStorageBlobProviderConfiguration> fileSystemConfigureAction)
    {
        configuration.ProviderType = typeof(LocalStorageBlobProvider);

        fileSystemConfigureAction(new LocalStorageBlobProviderConfiguration(configuration));

        return configuration;
    }
}
