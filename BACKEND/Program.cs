<<<<<<< HEAD
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
);
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
            HaviTorleszto = Math.Round(havi, 0),
            Visszafizetendo = Math.Round(visszafizet, 0)
        };
    });

    return Results.Json(ajanlatok);
});

app.Run();
=======
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
>>>>>>> d507bf86ce4a8ea3cfbd646ff45df1ff274b1b95
