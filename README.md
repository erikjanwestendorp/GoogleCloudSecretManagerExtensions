# GoogleCloudSecretManagerExtensions

# Configure Google Secret Manager

## Install Key Vault via Nuget

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
