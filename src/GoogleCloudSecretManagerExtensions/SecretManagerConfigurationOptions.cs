namespace GoogleCloudSecretManagerExtensions;

public class SecretManagerConfigurationOptions
{
    public SecretManager Manager { get; set; } = SecretManager.Instance;
}
