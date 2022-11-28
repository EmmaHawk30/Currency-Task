using Currency.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICurrencyConverter, CurrencyConverter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/convert-currency", (ICurrencyConverter currencyConverter, string convertFrom, string convertTo, decimal amountFrom) =>
{
    var results = currencyConverter.ConvertCurrency(convertFrom, convertTo, amountFrom);

    return results;

});

app.Run();