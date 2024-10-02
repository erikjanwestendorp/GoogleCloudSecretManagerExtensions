using Google.Api.Gax.ResourceNames;
using Google.Cloud.SecretManager.V1;
using Microsoft.Extensions.Configuration;

namespace GCP.DotNet.Extensions.SecretManager;

public class SecretManagerConfigurationProvider(string projectId, SecretManagerConfigurationOptions options, SecretManagerServiceClient secretManagerServiceClient) : ConfigurationProvider
{
    private readonly SecretManager _secretManager = options.Manager;

    public override void Load() => LoadAsync().GetAwaiter().GetResult();

    private async Task LoadAsync()
    {
        var secrets = secretManagerServiceClient.ListSecrets(new ListSecretsRequest
        {
            ParentAsProjectName = new ProjectName(projectId)
        });

        foreach (var secret in secrets)
        {
            try
            {
                var secretVersionName = new SecretVersionName(projectId, secret.SecretName.SecretId, "latest");
                var secretPayload = await secretManagerServiceClient.AccessSecretVersionAsync(secretVersionName);
                var secretData = secretPayload.Payload.Data.ToStringUtf8();

                var key = _secretManager.GetKey(secret);
                Data[key] = secretData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to retrieve secret {secret.SecretName.SecretId}: {ex.Message}");
            }
        }
    }
}