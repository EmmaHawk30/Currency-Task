using Currency.API.Exceptions;
using Currency.API.Models;
using System.Text.Json;

namespace Currency.API.Infrastructure;

public class JsonHandler : IJsonHandler
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions;

    public JsonHandler(HttpClient client)
    {
        _client = client;
        _jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
    }

    public async Task<ExchangeRates> DownloadSerializedJson(string url)
    {
        using var client = _client;

        var urlString = string.Empty;
        var json = string.Empty;

        ExchangeRates? result;

        try
        {
            urlString = await client.GetStringAsync(url);

            result = !string.IsNullOrEmpty(urlString) ? JsonSerializer.Deserialize<ExchangeRates>(urlString, _jsonOptions) : null;
        }
        catch (Exception ex)
        {
            throw new JsonHandlerException("Could not deserialize url string to an ExchangeRates object", ex);
        }

        if (result is null)
        {
            throw new JsonHandlerException("Exchange rate data is null");
        }

        return result;
    }
}
