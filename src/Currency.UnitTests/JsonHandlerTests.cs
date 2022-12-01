using Currency.API.Exceptions;
using Currency.API.Infrastructure;
using Currency.API.Models;
using ExpectedObjects;
using Moq;
using Moq.Protected;
using Shouldly;
using System.Net;

namespace Currency.UnitTests;

public class JsonHandlerTests
{
    [Fact]
    public async Task Returns_deserialized_json_in_correct_format_when_given_valid_url_string()
    {
        // Given
        var url = "http://test-url";

        var mockMessageHandler = new Mock<HttpMessageHandler>();

        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("{\"base\": \"GBP\", \"rates\": {\"GBP\": 1, \"USD\": 1.19, \"EUR\": 1.16}}"),
        };

        mockMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
              ItExpr.IsAny<HttpRequestMessage>(),
              ItExpr.IsAny<CancellationToken>())
           .ReturnsAsync(response);

        var httpClient = new HttpClient(mockMessageHandler.Object);

        var jsonHandler = new JsonHandler(httpClient);

        // When
        var actual = await jsonHandler.DownloadSerializedJson(url);

        // Then
        var expected = new ExchangeRates
        {
            Base = "GBP",
            Rates = new Dictionary<string, decimal>()
            {
                { "GBP", 1m },
                { "USD", 1.19m },
                { "EUR", 1.16m }
            }
        }.ToExpectedObject();

        expected.ShouldMatch(actual);
    }

    [Fact]
    public async Task Throws_when_url_string_is_null()
    {
        var url = "http://test-url";

        var mockMessageHandler = new Mock<HttpMessageHandler>();

        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = null
        };

        mockMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
              ItExpr.IsAny<HttpRequestMessage>(),
              ItExpr.IsAny<CancellationToken>())
           .ReturnsAsync(response);

        var httpClient = new HttpClient(mockMessageHandler.Object);

        var jsonHandler = new JsonHandler(httpClient);

        // When
        var exception = await Should.ThrowAsync<JsonHandlerException>(async () => { await jsonHandler.DownloadSerializedJson(url); });

        // Then
        exception.Message.ShouldBe("Exchange rate data is null");
    }

    [Fact]
    public async Task Throws_when_url_string_cannot_be_deserialized()
    {
        var url = "http://test-url";

        var mockMessageHandler = new Mock<HttpMessageHandler>();

        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("invalid"),
        };

        mockMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
              ItExpr.IsAny<HttpRequestMessage>(),
              ItExpr.IsAny<CancellationToken>())
           .ReturnsAsync(response);

        var httpClient = new HttpClient(mockMessageHandler.Object);

        var jsonHandler = new JsonHandler(httpClient);

        // When
        var exception = await Should.ThrowAsync<JsonHandlerException>(async () => { await jsonHandler.DownloadSerializedJson(url); });

        // Then
        exception.Message.ShouldBe("Could not deserialize url string to an ExchangeRates object");
    }
}
