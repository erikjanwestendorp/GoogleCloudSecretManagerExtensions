namespace GCP.DotNet.Extensions.SecretManager;

public class SecretManagerConfigurationOptions
{
    public SecretManager Manager { get; set; } = SecretManager.Instance;
}
