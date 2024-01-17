using VirtualStore.API.Configuration;
using VirtualStoreAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureSerilog();
builder.Services.ConfigureStartupConfiguration(builder.Configuration);

var app = builder.Build().UseStartupConfiguration();

app.Run();


