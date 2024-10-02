using GCP.DotNet.Extensions.SecretManager.Helpers;
using GCP.DotNet.Extensions.SecretManager.Helpers.Configuration;
using GCP.DotNet.Extensions.SecretManager.Helpers.Extensions;
using Google.Cloud.SecretManager.V1;

namespace GCP.DotNet.Extensions.SecretManager.DefaultTestSite.Compose;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureGoogleCloudSecretManagerDefault(this WebApplicationBuilder builder)
    {
        var projectId = builder.Configuration.GetConfiguredInstance<AppSettings.SecretManager>(ProjectConstants.SettingsSections.SecretManager).ProjectId;

        if (string.IsNullOrWhiteSpace(projectId))
        {
            throw new InvalidOperationException("ProjectId is not configured in appsettings.json under 'SecretManager:ProjectId'.");
        }

        builder.Configuration.AddGoogleCloudSecretManager(projectId);

        return builder;
    }

    public static WebApplicationBuilder ConfigureGoogleCloudSecretManagerClientBuilder(
        this WebApplicationBuilder builder)
    {
        var secretManagerSettings = builder.Configuration.GetConfiguredInstance<AppSettings.SecretManager>(ProjectConstants.SettingsSections.SecretManager);

        if (string.IsNullOrWhiteSpace(secretManagerSettings.ProjectId))
        {
            throw new InvalidOperationException("ProjectId is not configured in appsettings.json under 'SecretManager:ProjectId'.");
        }

        if (string.IsNullOrWhiteSpace(secretManagerSettings.CredentialsPath))
        {
            throw new InvalidOperationException("CredentialsPath is not configured in appsettings.json under 'SecretManager:CredentialsPath'.");
        }

        var secretClientBuilder = new SecretManagerServiceClientBuilder
        {
            CredentialsPath = secretManagerSettings.CredentialsPath
        };

        var secretManagerServiceClient = secretClientBuilder.Build();

        builder.Configuration.AddGoogleCloudSecretManager(secretManagerSettings.ProjectId, new SecretManagerConfigurationOptions(), secretManagerServiceClient);

        return builder;
    }
}
