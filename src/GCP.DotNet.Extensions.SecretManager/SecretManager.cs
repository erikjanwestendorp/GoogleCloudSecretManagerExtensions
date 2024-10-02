using Google.Cloud.SecretManager.V1;
using Microsoft.Extensions.Configuration;

namespace GCP.DotNet.Extensions.SecretManager;

public class SecretManager
{
    internal static SecretManager Instance { get; } = new();

    public virtual string GetKey(Secret secret)
    {
        return secret.SecretName.SecretId.Replace("--", ConfigurationPath.KeyDelimiter);
    }
}
