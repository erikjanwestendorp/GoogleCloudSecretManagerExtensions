﻿using Google.Api.Gax.ResourceNames;
using Google.Cloud.SecretManager.V1;
using Microsoft.Extensions.Configuration;

namespace GoogleCloudSecretManagerExtensions;

public class SecretManagerConfigurationProvider(string projectId, SecretManagerConfigurationOptions options) : ConfigurationProvider
{
    private readonly SecretManager _secretManager = options.Manager;

    public override void Load()
    {
        var secretManagerClient = SecretManagerServiceClient.Create();

        var secrets = secretManagerClient.ListSecrets(new ListSecretsRequest
        {
            ParentAsProjectName = new ProjectName(projectId)
        });

        foreach (var secret in secrets)
        {
            try
            {
                var secretVersionName = new SecretVersionName(projectId, secret.SecretName.SecretId, "latest");
                var secretPayload = secretManagerClient.AccessSecretVersion(secretVersionName);
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