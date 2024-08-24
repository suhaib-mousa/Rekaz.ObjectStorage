namespace Rekaz.BlobStoring.Aws;

public static class AwsBlobProviderConfigurationExtensions
{
    public static AwsBlobProviderConfiguration GetAwsConfiguration(
        this BlobStoringConfiguration configuration)
    {
        return new AwsBlobProviderConfiguration(configuration);
    }

    public static BlobStoringConfiguration UseAws(
        this BlobStoringConfiguration configuration,
        Action<AwsBlobProviderConfiguration> fileSystemConfigureAction)
    {
        fileSystemConfigureAction(new AwsBlobProviderConfiguration(configuration));

        return configuration;
    }
}
