using Volo.Abp;

namespace Rekaz.BlobStoring;

public class ConfigurationNotFoundException : AbpException
{
    public ConfigurationNotFoundException(string name)
        : base($"Configuration with the name '{name}' was not found.")
    {
    }
}