using GCP.DotNet.Extensions.SecretManager.UmbracoTestSite.Compose;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder
    //.ConfigureGoogleCloudSecretManagerDefault()
    .ConfigureGoogleCloudSecretManagerClientBuilder()
    .CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
