namespace Currency.API.Infrastructure;
public interface ICurrencyConverter
{
    Task<decimal> ConvertCurrency(IJsonHandler jsonHelper, string convertFrom, string convertTo, decimal amountFrom);
}
