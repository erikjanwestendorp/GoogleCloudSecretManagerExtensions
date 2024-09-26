namespace GoogleCloudSecretManagerExtensions.TestSite.Compose;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder Compose(this WebApplicationBuilder builder)
    {
        var projectId = "MyProjectId";

        builder.Configuration.AddGoogleCloudSecretManager(projectId);

        return builder;
    }
}
