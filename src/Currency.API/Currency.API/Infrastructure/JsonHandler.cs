using Currency.API.Exceptions;
using Currency.API.Models;
using System.Text.Json;

namespace Currency.API.Infrastructure;

public class JsonHandler : IJsonHandler
{
    private readonly JsonSerializerOptions _jsonOptions;

    public JsonHandler()
    {
        _jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
    }

    public async Task<ExchangeRates> DownloadSerializedJson(string url)
    {
        using var client = new HttpClient();

        var urlString = string.Empty;
        var json = string.Empty;

        try
        {
            urlString = await client.GetStringAsync(url);

            var result = !string.IsNullOrEmpty(urlString) ? JsonSerializer.Deserialize<ExchangeRates>(urlString, _jsonOptions) : new ExchangeRates();

            if (result is null)
            {
                throw new JsonHandlerException("Could not deserialize url string to an ExchangeRates object");
            }

            return result;

        }
        catch (Exception ex)
        {
            throw new JsonHandlerException($"Could not retrieve data from {url}", ex);
        }
    }
}
