namespace Consumer.DTO;

public interface IPriceREPO
{
    Task DoRecord(CurrencyEntity model);
}