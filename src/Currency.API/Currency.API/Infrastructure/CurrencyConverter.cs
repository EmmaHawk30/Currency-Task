using Currency.API.Exceptions;
using Currency.API.Models;

namespace Currency.API.Infrastructure;

public class CurrencyConverter : ICurrencyConverter
{
    private readonly IJsonHandler _jsonHandler;

    public CurrencyConverter(IJsonHandler jsonHandler)
    {
        _jsonHandler = jsonHandler;
    }

    public Task<decimal> ConvertCurrency(string convertFrom, string convertTo, decimal amount)
    {
        try
        {
            var exchangeRates = GetExchangeRates(convertFrom).Result;

            if (exchangeRates is null)
            {
                throw new CurrencyConverterException("Could not get exchange rates");
            }

            var result = amount * exchangeRates.Rates[$"{convertTo}"];

            return Task.FromResult(result);
        }
        catch (Exception ex)
        {
            throw new CurrencyConverterException($"Could not convert {convertFrom} to {convertTo}", ex);
        }
    }

    public async Task<ExchangeRates> GetExchangeRates(string convertFrom)
    {
        var exchangeRatesUrl = $"https://api.exchangerate.host/latest?base={convertFrom}";

        var exchangeRates = await _jsonHandler.DownloadSerializedJson(exchangeRatesUrl);

        return exchangeRates;
    }
}
