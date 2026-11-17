
using Scalar.AspNetCore;                 // 1. lets us use the Scalar method below
using AutoMapper;
using Saffayna.Infrastructure;
using Saffayna.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication(builder.Configuration["AutoMapper:LicenseKey"]);

builder.Services.AddInfrastructure(
    builder.Configuration.GetConnectionString("Default")!);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();         // 2. creates the API description (JSON)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();                    // 4. serves the JSON at /openapi/v1.json
    app.MapScalarApiReference();         // 5. serves the viewer page at /scalar/v1

    // Fail fast: throws at startup if any destination member is neither mapped nor ignored.
    // We go through IMapper because the name IConfigurationProvider also exists in
    // Microsoft.Extensions.Configuration (a global using in web projects), which would clash.
    app.Services.GetRequiredService<IMapper>().ConfigurationProvider.AssertConfigurationIsValid();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
