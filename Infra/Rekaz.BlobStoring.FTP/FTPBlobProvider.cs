using FluentFTP;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Rekaz.BlobStoring.FTP;

public class FTPBlobProvider : BlobProviderBase, ITransientDependency
{
    public async override Task<Stream?> GetOrNullAsync(BlobProviderGetArgs args)
    {
        var configuration = args.Configuration.GetFTPConfiguration();
        using var client = CreateFtpClient(configuration);
        client.Connect();

        var filePath = $"{configuration.RootPath}/{args.BlobName}";

        if (await Task.Run(() => client.FileExists(filePath)))
        {
            var stream = new MemoryStream();
            await Task.Run(() => client.DownloadStream(stream, filePath));
            stream.Position = 0;
            return stream;
        }

        return null;
    }

    public override async Task SaveAsync(BlobProviderSaveArgs args)
    {
        var configuration = args.Configuration.GetFTPConfiguration();
        using var client = CreateFtpClient(configuration);
        client.Connect();

        var filePath = $"{configuration.RootPath}/{args.BlobName}";

        try
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            if (!await Task.Run(() => client.DirectoryExists(directoryPath)))
            {
                await Task.Run(() => client.CreateDirectory(directoryPath));
            }

            await Task.Run(() => client.UploadStream(args.BlobStream, filePath, FtpRemoteExists.Overwrite));
        }
        catch (Exception ex)
        {
            throw new AbpException("An error occurred while saving the blob.", ex);
        }
    }
    private FtpClient CreateFtpClient(FTPBlobProviderConfiguration configuration)
    {
        var client = new FtpClient(configuration.ServerAddress, configuration.Username, configuration.Password)
        {
            Port = configuration.Port
        };

        return client;
    }
}
