using Google.Api.Gax.ResourceNames;
using Google.Cloud.SecretManager.V1;
using Microsoft.Extensions.Configuration;

namespace GoogleCloudSecretManagerExtensions;

public class GoogleCloudSecretManagerConfigurationProvider(string projectId) : ConfigurationProvider, IDisposable
{
    private readonly CancellationTokenSource _cancellationToken = new();
    private bool _disposed;

    public override void Load()
    {
        var secretManagerClient = SecretManagerServiceClient.Create();

        // Get all secret names in the project
        var secrets = secretManagerClient.ListSecrets(new ListSecretsRequest
        {
            ParentAsProjectName = new ProjectName(projectId)
        });

        foreach (var secret in secrets)
        {
            try
            {
                // Access the latest version of each secret
                var secretVersionName = new SecretVersionName(projectId, secret.SecretName.SecretId, "latest");
                var secretPayload = secretManagerClient.AccessSecretVersion(secretVersionName);
                var secretData = secretPayload.Payload.Data.ToStringUtf8();

                // Add the secret to the configuration
                Data[secret.SecretName.SecretId] = secretData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to retrieve secret {secret.SecretName.SecretId}: {ex.Message}");
            }
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (!_disposed)
            {
                _cancellationToken.Cancel();
                _cancellationToken.Dispose();
            }

            _disposed = true;
        }
    }
}
