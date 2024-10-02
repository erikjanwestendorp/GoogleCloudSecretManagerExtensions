using Google.Cloud.SecretManager.V1;
using Microsoft.Extensions.Configuration;

namespace GCP.DotNet.Extensions.SecretManager;

public class SecretManagerConfigurationSource(string projectId, SecretManagerConfigurationOptions options, SecretManagerServiceClient secretManagerServiceClient) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new SecretManagerConfigurationProvider(projectId, options, secretManagerServiceClient);
    }
}
