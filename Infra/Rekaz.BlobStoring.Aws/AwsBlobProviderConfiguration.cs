namespace Rekaz.BlobStoring.Aws;

public class AwsBlobProviderConfiguration
{
    public string? AccessKeyId
    {
        get => _configuration.GetConfiguration<string>(AwsBlobProviderConfigurationNames.AccessKeyId);
        set => _configuration.AddOrUpdateConfiguration(AwsBlobProviderConfigurationNames.AccessKeyId, value);
    }

    public string? SecretAccessKey
    {
        get => _configuration.GetConfiguration<string>(AwsBlobProviderConfigurationNames.SecretAccessKey);
        set => _configuration.AddOrUpdateConfiguration(AwsBlobProviderConfigurationNames.SecretAccessKey, value);
    }

    public string? Endpoint
    {
        get => _configuration.GetConfiguration<string>(AwsBlobProviderConfigurationNames.Endpoint);
        set => _configuration.AddOrUpdateConfiguration(AwsBlobProviderConfigurationNames.Endpoint, value);
    }

    public string? BucketName
    {
        get => _configuration.GetConfiguration<string>(AwsBlobProviderConfigurationNames.BucketName);
        set => _configuration.AddOrUpdateConfiguration(AwsBlobProviderConfigurationNames.BucketName, value);
    }
    

    public string? Region
    {
        get => _configuration.GetConfiguration<string>(AwsBlobProviderConfigurationNames.Region);
        set => _configuration.AddOrUpdateConfiguration(AwsBlobProviderConfigurationNames.Region, value);
    }

    private readonly BlobStoringConfiguration _configuration;

    public AwsBlobProviderConfiguration(BlobStoringConfiguration configuration)
    {
        _configuration = configuration;
    }
}
