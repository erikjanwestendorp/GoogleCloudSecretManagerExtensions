using Microsoft.Extensions.Configuration;

namespace GoogleCloudSecretManagerExtensions;

public static class GoogleCloudSecretManagerConfigurationExtensions
{
    public static IConfigurationBuilder AddGoogleCloudSecretManager(this IConfigurationBuilder configurationBuilder, string projectId)
    {
        configurationBuilder.Add(new SecretManagerConfigurationSource(projectId));
        return configurationBuilder;
    }
}
