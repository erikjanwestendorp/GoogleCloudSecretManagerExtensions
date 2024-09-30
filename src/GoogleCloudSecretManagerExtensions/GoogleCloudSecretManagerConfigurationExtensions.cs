using Microsoft.Extensions.Configuration;

namespace GoogleCloudSecretManagerExtensions;

public static class GoogleCloudSecretManagerConfigurationExtensions
{
    public static IConfigurationBuilder AddGoogleCloudSecretManager(
        this IConfigurationBuilder configurationBuilder, 
        string projectId)
    {
        return AddGoogleCloudSecretManager(configurationBuilder, projectId, SecretManager.Instance);
    }

    public static IConfigurationBuilder AddGoogleCloudSecretManager(
        this IConfigurationBuilder configurationBuilder,
        string projectId, 
        SecretManager secretManager)
    {
        return AddGoogleCloudSecretManager(configurationBuilder, projectId, new SecretManagerConfigurationOptions
        {
            Manager = secretManager
        });
    }

    public static IConfigurationBuilder AddGoogleCloudSecretManager(
        this IConfigurationBuilder configurationBuilder,
        string projectId,
        SecretManagerConfigurationOptions options)
    {
        configurationBuilder.Add(new SecretManagerConfigurationSource(projectId, options));
        return configurationBuilder;
    }

}
