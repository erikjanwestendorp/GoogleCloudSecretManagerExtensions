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
        var projectId = "dogwood-concept-429614-j5";

        builder.Configuration.AddGoogleCloudSecretManager(projectId);

        return builder;
    }
}
