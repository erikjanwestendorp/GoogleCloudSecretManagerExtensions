namespace GoogleCloudSecretManagerExtensions.TestSite.Compose;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder Compose(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddGoogleCloudSecretManager();

        return builder;
    }
}
