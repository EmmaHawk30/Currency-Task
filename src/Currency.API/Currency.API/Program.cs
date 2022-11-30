using Currency.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICurrencyConverter, CurrencyConverter>();
builder.Services.AddScoped<IJsonHandler, JsonHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/convert-currency", (IJsonHandler jsonHandler, ICurrencyConverter currencyConverter, string convertFrom, string convertTo, decimal amount) =>
{
    var results = currencyConverter.ConvertCurrency(jsonHandler, convertFrom, convertTo, amount);

    return results;

});

app.Run();