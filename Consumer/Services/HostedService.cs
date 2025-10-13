namespace Consumer.Services;

public class HostedService(ICollectionService collectionService, AppSettings appSettings)
    : IHostedService, IDisposable, IAsyncDisposable
{
    private Timer _timer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(Consume, null, TimeSpan.Zero, TimeSpan.FromSeconds(appSettings.TimePeriod));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose() => _timer.Dispose();

    public async ValueTask DisposeAsync()
    {
        await _timer.DisposeAsync();
    }

    private async void Consume(object args)
    {
        try
        {
            await collectionService.DoRecord();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Host catch: {exception.Message}");
        }
    }
}