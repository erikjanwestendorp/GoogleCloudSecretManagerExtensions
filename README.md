# GCP.DotNet.Extensions.SecretManager 
`GCP.DotNet.Extensions.SecretManager` is a .NET library designed to simplify the integration of Google Cloud Secret Manager into your .NET applications. It provides a straightforward way to access and manage secrets stored in Google Cloud Secret Manager, enhancing the security and maintainability of your applications.

## Installation
To install the `GCP.DotNet.Extensions.SecretManager` library, add the package to your project using the .NET CLI:

```
dotnet add package GoogleCloudSecretManagerExtensions
```

Alternatively, you can add the package reference directly to your project file:

```
<PackageReference Include="GoogleCloudSecretManagerExtensions" Version="1.0.0" />
```

## Usage
### Automatic Configuration Integration
The library extends the `ConfigurationProvider` in .NET, allowing secrets to be automatically injected into your application's configuration. Once configured, your application can access secrets as if they were part of the app's standard configuration (e.g., appsettings.json).

### Example

```csharp
using Microsoft.Extensions.Configuration;
using GoogleCloudSecretManagerExtensions;

var builder = new ConfigurationBuilder();

// Add Google Cloud Secret Manager as a configuration source
builder.AddGoogleCloudSecrets("your-project-id");

var configuration = builder.Build();

// Access secrets from the configuration
string secretValue = configuration["your-secret-id"];

Console.WriteLine($"Retrieved secret from configuration: {secretValue}");
```
### How It Works
1. The `AddGoogleCloudSecrets` extension method integrates the Google Cloud Secret Manager as a configuration source.
2. Secrets from Google Cloud Secret Manager are automatically loaded and made available through the `IConfiguration` interface.
3. Secrets can be accessed just like any other configuration key/value pair.

## Authentication
Ensure that your application has the appropriate permissions to access Google Cloud Secret Manager and that you've set up authentication using a service account. You can configure authentication by setting the `GOOGLE_APPLICATION_CREDENTIALS` environment variable.

# Contributing
Contributions are welcome! If you encounter issues or have suggestions for improvements, please open an issue or submit a pull request.

License
This project is licensed under the MIT License. See the LICENSE file for more details.
