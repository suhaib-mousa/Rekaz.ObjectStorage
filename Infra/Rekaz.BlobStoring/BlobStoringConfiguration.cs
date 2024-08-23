using JetBrains.Annotations;
using Volo.Abp;

namespace Rekaz.BlobStoring;

public class BlobStoringConfiguration
{
    public Type? ProviderType { get; set; }

    [NotNull] private readonly Dictionary<string, object?> _configurationProperties;
    public BlobStoringConfiguration()
    {
        _configurationProperties = new Dictionary<string, object?>();
    }
    public T GetConfiguration<T>(string name)
    {
        if (!_configurationProperties.ContainsKey(name))
        {
            throw new ConfigurationNotFoundException($"Configuration with the name '{name}' was not found.");
        }
        return (T)_configurationProperties.GetOrDefault(name)!;
    }

    [NotNull]
    public BlobStoringConfiguration AddOrUpdateConfiguration([NotNull] string name, object? value)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Check.NotNull(value, nameof(value));

        _configurationProperties[name] = value;

        return this;
    }
}