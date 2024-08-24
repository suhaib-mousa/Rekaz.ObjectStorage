namespace Rekaz.BlobStoring.FTP;

public class FTPBlobProviderConfiguration
{
    public string ServerAddress
    {
        get => _configuration.GetConfiguration<string>(FTPBlobProviderConfigurationNames.ServerAddress);
        set => _configuration.AddOrUpdateConfiguration(FTPBlobProviderConfigurationNames.ServerAddress, value);
    }

    public int Port
    {
        get => _configuration.GetConfiguration<int>(FTPBlobProviderConfigurationNames.Port);
        set => _configuration.AddOrUpdateConfiguration(FTPBlobProviderConfigurationNames.Port, value);
    }

    public string Username
    {
        get => _configuration.GetConfiguration<string>(FTPBlobProviderConfigurationNames.Username);
        set => _configuration.AddOrUpdateConfiguration(FTPBlobProviderConfigurationNames.Username, value);
    }

    public string Password
    {
        get => _configuration.GetConfiguration<string>(FTPBlobProviderConfigurationNames.Password);
        set => _configuration.AddOrUpdateConfiguration(FTPBlobProviderConfigurationNames.Password, value);
    }

    public string RootPath
    {
        get => _configuration.GetConfiguration<string>(FTPBlobProviderConfigurationNames.RootPath);
        set => _configuration.AddOrUpdateConfiguration(FTPBlobProviderConfigurationNames.RootPath, value);
    }
    private readonly BlobStoringConfiguration _configuration;

    public FTPBlobProviderConfiguration(BlobStoringConfiguration configuration)
    {
        _configuration = configuration;
    }
}
