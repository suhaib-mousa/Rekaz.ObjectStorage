using Volo.Abp.DependencyInjection;

namespace Rekaz.BlobStoring.Aws;

public class AwsObjectKeyCalculator : IAwsObjectKeyCalculator, ITransientDependency
{
    public string Calculate(BlobProviderArgs args)
    {
        var configuration = args.Configuration.GetAwsConfiguration();

        var segments = new List<string>();
        if (!string.IsNullOrEmpty(configuration.Container))
        {
            segments.Add(configuration.Container);
        }

        segments.Add(args.BlobName);

        return string.Join("/", segments);
    }
}