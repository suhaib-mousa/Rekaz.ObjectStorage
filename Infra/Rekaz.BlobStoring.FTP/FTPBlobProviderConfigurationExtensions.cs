namespace Rekaz.BlobStoring.FTP;

public static class FTPBlobProviderConfigurationExtensions
{
    public static FTPBlobProviderConfiguration GetFTPConfiguration(
        this BlobStoringConfiguration configuration)
    {
        return new FTPBlobProviderConfiguration(configuration);
    }
    public static BlobStoringConfiguration UseFTP(
            this BlobStoringConfiguration configuration,
            Action<FTPBlobProviderConfiguration> configureAction)
    {
        var ftpConfig = new FTPBlobProviderConfiguration(configuration);
        configureAction(ftpConfig);
        return configuration;
    }
}
