namespace Consumer.DTO;

public interface IDataRepo
{
    Task<bool> DoRecord(CurrencyEntity entity);
}