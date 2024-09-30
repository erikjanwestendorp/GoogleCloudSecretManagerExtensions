using Microsoft.Extensions.Configuration;

namespace GoogleCloudSecretManagerExtensions;

public class SecretManagerConfigurationSource(string projectId, SecretManagerConfigurationOptions options) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new SecretManagerConfigurationProvider(projectId, options);
    }
}
