using Currency.API.Exceptions;
using Currency.API.Infrastructure;
using Currency.API.Models;
using Moq;
using Shouldly;

namespace Currency.UnitTests;

public class CurrencyConverterTests
{
    private readonly Mock<IJsonHandler> _mockJsonHandler;

    public CurrencyConverterTests()
    {
        _mockJsonHandler = new Mock<IJsonHandler>();
    }

    [Fact]
    public async Task Returns_correct_converted_currency_when_given_valid_parameters()
    {
        // Given
        var convertFrom = "GBP";
        var convertTo = "USD";
        var amount = 1m;

        var exchangeRates = new ExchangeRates
        {
            Base = "GBP",
            Rates = new Dictionary<string, decimal>()
            {
                { "GBP", 1m },
                { "USD", 1.19m },
                { "EUR", 1.16m }
            }
        };

        _mockJsonHandler.Setup(x => x.DownloadSerializedJson(It.IsAny<string>())).ReturnsAsync(exchangeRates);

        var currencyConverter = new CurrencyConverter(_mockJsonHandler.Object);

        // When
        var actual = await currencyConverter.ConvertCurrency(convertFrom, convertTo, amount);

        // Then
        var expected = 1.19m;

        Assert.Equal(actual, expected);
    }

    [Fact]
    public async Task Throws_when_exchange_rates_object_is_null()
    {
        // Given
        var convertFrom = "GBP";
        var convertTo = "USD";
        var amount = 1m;

        var exchangeRates = new ExchangeRates();

        _mockJsonHandler.Setup(x => x.DownloadSerializedJson(It.IsAny<string>())).ThrowsAsync(new Exception("some error"));

        var currencyConverter = new CurrencyConverter(_mockJsonHandler.Object);

        // When
        var exception = await Should.ThrowAsync<CurrencyConverterException>(async () => { await currencyConverter.ConvertCurrency(convertFrom, convertTo, amount); });

        // Then
        exception.Message.ShouldBe("Could not convert GBP to USD");
    }

    [Fact]
    public async Task Throws_when_given_an_invalid_currency()
    {
        // Given
        var convertFrom = "GBP";
        var convertTo = "invalid";
        var amount = 1m;

        var exchangeRates = new ExchangeRates
        {
            Base = "GBP",
            Rates = new Dictionary<string, decimal>()
            {
                { "GBP", 1m },
                { "USD", 1.19m },
                { "EUR", 1.16m }
            }
        };

        _mockJsonHandler.Setup(x => x.DownloadSerializedJson(It.IsAny<string>())).ReturnsAsync(exchangeRates);

        var currencyConverter = new CurrencyConverter(_mockJsonHandler.Object);

        // When
        var exception = await Should.ThrowAsync<CurrencyConverterException>(async () => { await currencyConverter.ConvertCurrency(convertFrom, convertTo, amount); });

        // Then
        exception.Message.ShouldBe($"Could not convert {convertFrom} to {convertTo}");
    }
}
