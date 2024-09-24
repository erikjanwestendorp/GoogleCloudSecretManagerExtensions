using Microsoft.Extensions.Configuration;

namespace GoogleCloudSecretManagerExtensions;

public static class GoogleCloudSecretManagerConfigurationExtensions
{
    public static IConfigurationBuilder AddGoogleCloudSecretManager(this IConfigurationBuilder configurationBuilder)
    {
        return configurationBuilder;
    }
}
