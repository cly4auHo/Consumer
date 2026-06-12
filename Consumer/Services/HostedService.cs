using System.Text.Json;
using Consumer.API;

namespace Consumer.Services;

public class HostedService(AppSettings appSettings, ICollectionService collectionService) : IHostedService, IDisposable, IAsyncDisposable
{
    private readonly HttpClient httpClient = new();
    private Timer? timer;
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(appSettings.Period));
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        
    }
    
    private async void DoWork(object? state)
    {
        foreach (var сurrency in appSettings.Сurrencies)
        {
            var response = await httpClient.GetAsync($"https://api.binance.com/api/v3/ticker/price?symbol={сurrency}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<PriceRequestData>(json);
        }
    }
    
    public async ValueTask DisposeAsync()
    {
        if (timer != null) 
            await timer.DisposeAsync();
    }
    
    public void Dispose() => timer?.Dispose();
}