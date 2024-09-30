namespace GoogleCloudSecretManagerExtensions.TestSite.Compose;

public static class WebApplicationBuilderExtensions
{
    public static IUmbracoBuilder CreateUmbracoBuilder(this WebApplicationBuilder builder, bool composeWebApplicationBuilder)
    {
        if (composeWebApplicationBuilder)
        {
            builder.Compose();
        }

        return builder.CreateUmbracoBuilder();
    }

    public static WebApplicationBuilder Compose(this WebApplicationBuilder builder)
    {
        var projectId = builder.Configuration.GetConfiguredInstance<AppSettings.SecretManager>(ProjectConstants.SettingsSections.SecretManager).ProjectId;
        
        if (string.IsNullOrWhiteSpace(projectId))
        {
            throw new InvalidOperationException("ProjectId is not configured in appsettings.json under 'SecretManager:ProjectId'.");
        }

        builder.Configuration.AddGoogleCloudSecretManager(projectId);

        return builder;
    }
}
