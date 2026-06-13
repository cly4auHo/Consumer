using System.Globalization;
using Consumer.API;
using Consumer.DTO;

namespace Consumer.Services;

public class CollectionService(IDataRepo dataRepo) : ICollectionService
{
    public async Task<bool> DoRecord(PriceRequestData data)
    {
        try
        {
            var model = new CurrencyEntity
            {
                Currency = data.Symbol,
                Price = double.Parse(data.Price, CultureInfo.InvariantCulture),
                Time = DateTime.UtcNow
            };
        
            return await dataRepo.DoRecord(model);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}