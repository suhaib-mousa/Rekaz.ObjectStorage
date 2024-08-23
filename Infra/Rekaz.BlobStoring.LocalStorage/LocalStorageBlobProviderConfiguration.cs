using Volo.Abp;

namespace Rekaz.BlobStoring.LocalStorage;

public class LocalStorageBlobProviderConfiguration
{
    public string BasePath
    {
        get => _configuration.GetConfiguration<string>(LocalStorageBlobProviderConfigurationNames.BasePath);
        set => _configuration.AddOrUpdateConfiguration(LocalStorageBlobProviderConfigurationNames.BasePath, Check.NotNullOrWhiteSpace(value, nameof(value)));
    }
    private readonly BlobStoringConfiguration _configuration;

    public LocalStorageBlobProviderConfiguration(BlobStoringConfiguration configuration)
    {
        _configuration = configuration;
    }
}
