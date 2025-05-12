var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
);
