using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);

// Helyes CORS konfiguráció
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://127.0.0.1:5500") // Ez a Live Server origin
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Ez fontos: ez aktiválja a CORS-t
app.UseCors("AllowFrontend");

app.MapGet("/api/ajanlatok", (double osszeg, double kamat) =>
{
    var evek = new[] { 5, 10, 15, 20, 25, 30 };
    var ajanlatok = evek.Select(ev =>
    {
        var r = kamat / 12 / 100;
        var n = ev * 12;
        var havi = osszeg * r * Math.Pow(1 + r, n) / (Math.Pow(1 + r, n) - 1);
        var visszafizet = havi * n;

        return new
        {
            Ev = ev,
            HaviTorleszto = Math.Round(havi),
            Visszafizetendo = Math.Round(visszafizet)
        };
    });

    return Results.Json(ajanlatok, new JsonSerializerOptions { PropertyNamingPolicy = null });

});

app.Run();
