using Currency.API.Exceptions;
using Currency.API.Models;
using System.Net;
using System.Text.Json;

namespace Currency.API.Helpers;

public class JsonHelper : IJsonHelper
{
    private readonly JsonSerializerOptions _jsonOptions;

    public JsonHelper()
    {
        _jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true } ;
    }

    public async Task<ExchangeRates?> DownloadSerializedJson(string url)
    {
        using var client = new HttpClient();

        var urlString = string.Empty;
        var json = string.Empty;

        try
        {
            urlString = await client.GetStringAsync(url);
        }
        catch (Exception ex) 
        {
            throw new JsonHelperException($"Could not retrieve data from {url}", ex);
        }

        var result = !string.IsNullOrEmpty(urlString) ? JsonSerializer.Deserialize<ExchangeRates>(urlString, _jsonOptions) : new ExchangeRates();

        return result;
    }
}
