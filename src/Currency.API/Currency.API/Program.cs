using Currency.API.Helpers;
using Currency.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICurrencyConverter, CurrencyConverter>();
builder.Services.AddScoped<IJsonHelper, JsonHelper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/convert-currency", (IJsonHelper jsonHelper, ICurrencyConverter currencyConverter, string convertFrom, string convertTo, decimal amount) =>
{
    var results = currencyConverter.ConvertCurrency(jsonHelper, convertFrom, convertTo, amount);

    return results;

});

app.Run();