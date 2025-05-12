<<<<<<< HEAD
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
);
=======
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
>>>>>>> d507bf86ce4a8ea3cfbd646ff45df1ff274b1b95
