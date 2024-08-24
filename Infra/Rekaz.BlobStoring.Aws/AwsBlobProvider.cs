using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Rekaz.BlobStoring.Aws
{
    public class AwsBlobProvider : BlobProviderBase, ITransientDependency
    {
        private readonly IAwsObjectKeyCalculator _awsObjectKeyCalculator;

        public AwsBlobProvider(IAwsObjectKeyCalculator awsObjectKeyCalculator)
        {
            _awsObjectKeyCalculator = awsObjectKeyCalculator;
        }

        public override async Task<Stream?> GetOrNullAsync(BlobProviderGetArgs args)
        {
            var (client, objectKey) = GetClientAndObjectKey(args);

            try
            {
                return await client.DownloadStreamAsync(objectKey);
            }
            catch (Exception ex)
            {
                throw new AbpException($"Could not get blob '{args.BlobName}'", ex);
            }
        }

        public override async Task SaveAsync(BlobProviderSaveArgs args)
        {
            var (client, objectKey) = GetClientAndObjectKey(args);

            try
            {
                using var stream = args.BlobStream;
                await client.UploadStreamAsync(objectKey, stream);
            }
            catch (Exception ex)
            {
                throw new AbpException($"Could not save blob '{args.BlobName}'", ex);
            }
        }

        private (AwsS3Client Client, string ObjectKey) GetClientAndObjectKey(BlobProviderArgs args)
        {
            var configuration = args.Configuration.GetAwsConfiguration();
            var objectKey = _awsObjectKeyCalculator.Calculate(args);

            var client = new AwsS3Client(
                configuration.AccessKeyId,
                configuration.SecretAccessKey,
                configuration.Region,
                configuration.BucketName);

            return (client, objectKey);
        }
    }
}