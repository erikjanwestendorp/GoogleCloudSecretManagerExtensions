﻿using Google.Cloud.SecretManager.V1;
using Microsoft.Extensions.Configuration;

namespace GCP.DotNet.Extensions.SecretManager;

public static class GoogleCloudSecretManagerConfigurationExtensions
{
    /// <summary>
    /// Adds Google Cloud Secret Manager as a configuration source to the <see cref="IConfigurationBuilder"/>.
    /// </summary>
    /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to which the secret manager configuration source will be added.</param>
    /// <param name="projectId">The Google Cloud project ID where the secrets are stored.</param>
    /// <returns>The updated <see cref="IConfigurationBuilder"/>.</returns>
    public static IConfigurationBuilder AddGoogleCloudSecretManager(
        this IConfigurationBuilder configurationBuilder,
        string projectId)
    {
        return AddGoogleCloudSecretManager(configurationBuilder, projectId, SecretManager.Instance);
    }

    /// <summary>
    /// Adds Google Cloud Secret Manager as a configuration source to the <see cref="IConfigurationBuilder"/>, using a custom <see cref="SecretManager"/>.
    /// </summary>
    /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to which the secret manager configuration source will be added.</param>
    /// <param name="projectId">The Google Cloud project ID where the secrets are stored.</param>
    /// <param name="secretManager">An instance of <see cref="SecretManager"/> used to retrieve secrets from Google Cloud.</param>
    /// <returns>The updated <see cref="IConfigurationBuilder"/>.</returns>
    public static IConfigurationBuilder AddGoogleCloudSecretManager(
        this IConfigurationBuilder configurationBuilder,
        string projectId,
        SecretManager secretManager)
    {
        return AddGoogleCloudSecretManager(configurationBuilder, projectId, new SecretManagerConfigurationOptions
        {
            Manager = secretManager
        });
    }

    /// <summary>
    /// Adds Google Cloud Secret Manager as a configuration source to the <see cref="IConfigurationBuilder"/>, using custom configuration options.
    /// </summary>
    /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to which the secret manager configuration source will be added.</param>
    /// <param name="projectId">The Google Cloud project ID where the secrets are stored.</param>
    /// <param name="options">An instance of <see cref="SecretManagerConfigurationOptions"/> that provides additional options for configuring the secret manager.</param>
    /// <returns>The updated <see cref="IConfigurationBuilder"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="configurationBuilder"/>, <paramref name="projectId"/>, or <paramref name="options"/> are null.</exception>
    public static IConfigurationBuilder AddGoogleCloudSecretManager(
        this IConfigurationBuilder configurationBuilder,
        string projectId,
        SecretManagerConfigurationOptions options)
    {
        var client = SecretManagerServiceClient.Create();
        return AddGoogleCloudSecretManager(configurationBuilder, projectId, options, client);
    }

    /// <summary>
    /// Adds Google Cloud Secret Manager as a configuration source to the <see cref="IConfigurationBuilder"/>, 
    /// using custom configuration options and an explicit <see cref="SecretManagerServiceClient"/>.
    /// </summary>
    /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to which the secret manager configuration source will be added.</param>
    /// <param name="projectId">The Google Cloud project ID where the secrets are stored.</param>
    /// <param name="options">An instance of <see cref="SecretManagerConfigurationOptions"/> that provides additional options for configuring the secret manager.</param>
    /// <param name="client">An instance of <see cref="SecretManagerServiceClient"/> used to interact with Google Cloud Secret Manager.</param>
    /// <returns>The updated <see cref="IConfigurationBuilder"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="configurationBuilder"/>, <paramref name="projectId"/>, <paramref name="options"/>, or <paramref name="client"/> are null.</exception>

    public static IConfigurationBuilder AddGoogleCloudSecretManager(
        this IConfigurationBuilder configurationBuilder,
        string projectId,
        SecretManagerConfigurationOptions options,
        SecretManagerServiceClient client)
    {
        ArgumentNullException.ThrowIfNull(configurationBuilder);
        ArgumentNullException.ThrowIfNull(projectId);
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(client);

        configurationBuilder.Add(new SecretManagerConfigurationSource(projectId, options, client));
        return configurationBuilder;
    }
}
