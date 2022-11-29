using Currency.API.Models;
using IJsonHelper = Currency.API.Helpers.IJsonHelper;

namespace Currency.API.Infrastructure;

public class CurrencyConverter : ICurrencyConverter
{
    public Task<decimal> ConvertCurrency(IJsonHelper jsonHelper, string convertFrom, string convertTo, decimal amountFrom)
    {
        var rate = GetExchangeRates(jsonHelper, convertFrom).Result;

        var result = amountFrom * rate.Rates[$"{convertTo}"];

        return Task.FromResult(result);
    }

    public Task<ExchangeRates?> GetExchangeRates(IJsonHelper jsonHelper, string convertFrom)
    {
        var exchangeRatesUrl = $"https://api.exchangerate.host/latest?base={convertFrom}";

        var exchangeRates = jsonHelper.DownloadSerializedJson(exchangeRatesUrl);

        return exchangeRates;
    }
}
