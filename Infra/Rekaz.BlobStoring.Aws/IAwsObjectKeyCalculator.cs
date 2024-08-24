namespace Rekaz.BlobStoring.Aws;

public interface IAwsObjectKeyCalculator
{
    string Calculate(BlobProviderArgs args);
}
