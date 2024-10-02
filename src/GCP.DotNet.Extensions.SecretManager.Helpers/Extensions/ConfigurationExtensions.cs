using Microsoft.Extensions.Configuration;

namespace GCP.DotNet.Extensions.SecretManager.Helpers.Extensions;

public static class ConfigurationExtensions
{
    public static T GetConfiguredInstance<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var instance = new T();

        var section = configuration.GetSection(sectionName);
        section.Bind(instance);

        return instance;
    }
}