using Microsoft.Extensions.Configuration;
using System.Threading;

namespace GoogleCloudSecretManagerExtensions;

public class GoogleCloudSecretManagerConfigurationProvider : ConfigurationProvider, IDisposable
{
    private readonly CancellationTokenSource _cancellationToken = new();
    private bool _disposed;

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
