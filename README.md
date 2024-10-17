# Configure Google Secret Manager

## Install Package via Nuget

## Install through command line

Navigate to your project folder, which is the folder that contains your `.csproj` file. Now use the following `dotnet add package` command to install the packages:

```
dotnet add package GCP.DotNet.Extensions.SecretManager
```

### Configuration

The next step is to add the `ProjectId` to the `appsettings.json` file, like so: 

```json
{
  "$schema": "appsettings-schema.json",
  "SecretManager": {
    "ProjectId": "{your_project_id}",
  }
}
```

After adding the project id to this appsettings is't time to add some configuration so that the SecretManager is used. One way to achieve this is to create an extension method like so: 

```csharp
public static WebApplicationBuilder ConfigureGoogleCloudSecretManagerDefault(this WebApplicationBuilder builder)
{
    var projectId = builder.Configuration.GetConfiguredInstance<AppSettings.SecretManager>(ProjectConstants.SettingsSections.SecretManager).ProjectId;
    
    if (string.IsNullOrWhiteSpace(projectId))
    {
        throw new InvalidOperationException("ProjectId is not configured in appsettings.json under 'SecretManager:ProjectId'.");
    }

    builder.Configuration.AddGoogleCloudSecretManager(projectId);

    return builder;
}
```

After creating the extension method, it's possible to call it from the Program.cs class, like so:

```csharp
var builder = WebApplication.CreateBuilder(args);
...
builder.ConfigureGoogleCloudSecretManagerDefault();
...
```
