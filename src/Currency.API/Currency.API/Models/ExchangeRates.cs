namespace Currency.API.Models;

public class ExchangeRates
{
    public string Base { get; set; } = null!;
    public Dictionary<string, decimal> Rates { get; set; } = null!;
}