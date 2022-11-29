using Currency.API.Models;

namespace Currency.API.Helpers;

public interface IJsonHelper
{
    Task<ExchangeRates?> DownloadSerializedJson(string url);
}
