using Consumer.API;

namespace Consumer.Services;

public interface ICollectionService
{
    Task<bool> DoRecord(PriceRequestData model);
}