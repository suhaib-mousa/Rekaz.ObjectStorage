namespace Rekaz.BlobStoring.LocalStorage;

public static class LocalStorageBlobProviderConfigurationExtensions
{
    public static LocalStorageBlobProviderConfiguration GetLocalStorageConfiguration(
        this BlobStoringConfiguration configuration)
    {
        return new LocalStorageBlobProviderConfiguration(configuration);
    }

    public static void UseLocalStorage(
        this BlobStoringConfiguration configuration,
        Action<LocalStorageBlobProviderConfiguration> localStorageConfigureAction)
    {

        localStorageConfigureAction(new LocalStorageBlobProviderConfiguration(configuration));
    }
}
