using Currency.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICurrencyConverter, CurrencyConverter>();
builder.Services.AddScoped<IJsonHandler, JsonHandler>();
builder.Services.AddScoped<HttpClient, HttpClient>();

builder.Services.AddCors(options => options.AddPolicy("CorsApi", builder =>
{
    builder.WithOrigins("http://localhost:4200", "http://www.currency-converter.com")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsApi");

app.MapPost("api/convert-currency", (ICurrencyConverter currencyConverter, string convertFrom, string convertTo, decimal amount) =>
{
    var results = currencyConverter.ConvertCurrency(convertFrom, convertTo, amount);

    return results;

});

app.Run();