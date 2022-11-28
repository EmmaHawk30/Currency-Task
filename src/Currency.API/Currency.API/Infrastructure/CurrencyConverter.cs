namespace Currency.API.Infrastructure;

public class CurrencyConverter : ICurrencyConverter
{
    public Task<decimal> ConvertCurrency(string convertFrom, string convertTo, decimal amountFrom)
    {
        var rate = GetExchangeRate(convertFrom, convertTo).Result;

        var result = rate * amountFrom;

        return Task.FromResult(result);
    }

    public Task<decimal> GetExchangeRate(string convertFrom, string convertTo)
    {
        throw new NotImplementedException();
    }
}
