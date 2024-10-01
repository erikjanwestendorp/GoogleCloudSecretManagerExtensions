using Microsoft.Extensions.Configuration;
using Google.Cloud.SecretManager.V1;

namespace GoogleCloudSecretManagerExtensions;

public class SecretManagerConfigurationSource(string projectId, SecretManagerConfigurationOptions options, SecretManagerServiceClient secretManagerServiceClient) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new SecretManagerConfigurationProvider(projectId, options, secretManagerServiceClient);
    }
}
