using Microsoft.Extensions.Configuration;

namespace GoogleCloudSecretManagerExtensions;

public class SecretManagerConfigurationSource(string projectId) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new SecretManagerConfigurationProvider(projectId);
    }
}
