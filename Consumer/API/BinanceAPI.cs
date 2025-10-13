using System.Net;
using System.Text;
using System.Text.Json;

namespace Consumer.API;

public class BinanceAPI : IServer
{
    private readonly HttpClient _client;
    
    public BinanceAPI()
    {
        var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All };
        _client = new HttpClient(handler);
    }
    
    public async Task<BinanceResponseModel> GetCurrency(string currencyName)  
    {
        var responce = await GetAsync($"https://api.binance.com/api/v3/ticker/price?symbol={currencyName}USDT");

        if (string.IsNullOrEmpty(responce))
            return null;

        try
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            
            return JsonSerializer.Deserialize<BinanceResponseModel>(responce, options);
        }
        catch
        {
            return null;
        }
    }
    
    private async Task<string> GetAsync(string uri)
    {
        using var response = await _client.GetAsync(uri);

        return await response.Content.ReadAsStringAsync();
    }

    private async Task<string> PostAsync(string uri, string data, string contentType)
    {
        using HttpContent content = new StringContent(data, Encoding.UTF8, contentType);

        var requestMessage = new HttpRequestMessage()
        {
            Content = content,
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri)
        };

        using var response = await _client.SendAsync(requestMessage);

        return await response.Content.ReadAsStringAsync();
    }
}