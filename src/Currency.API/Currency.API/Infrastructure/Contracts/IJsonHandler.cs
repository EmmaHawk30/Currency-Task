using Currency.API.Models;

namespace Currency.API.Infrastructure;

public interface IJsonHandler
{
    Task<ExchangeRates> DownloadSerializedJson(string url);
}
