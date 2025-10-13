namespace Consumer.API;

public interface IServer
{
    Task<BinanceResponseModel> GetCurrency(string currencyName);
}