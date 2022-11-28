namespace Currency.API.Infrastructure;
public interface ICurrencyConverter
{
    Task<decimal> ConvertCurrency(string convertFrom, string convertTo, decimal amountFrom);
    Task<decimal> GetExchangeRate(string convertFrom, string convertTo);
}
