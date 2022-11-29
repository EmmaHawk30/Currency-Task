using Currency.API.Helpers;
using Currency.API.Models;

namespace Currency.API.Infrastructure;
public interface ICurrencyConverter
{
    Task<decimal> ConvertCurrency(IJsonHelper jsonHelper, string convertFrom, string convertTo, decimal amountFrom);
    Task<ExchangeRates?> GetExchangeRates(IJsonHelper jsonHelper, string convertFrom);
}
