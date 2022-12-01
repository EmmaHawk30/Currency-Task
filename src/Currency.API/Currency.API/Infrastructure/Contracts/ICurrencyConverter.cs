namespace Currency.API.Infrastructure;
public interface ICurrencyConverter
{
    Task<decimal> ConvertCurrency(string convertFrom, string convertTo, decimal amountFrom);
}
