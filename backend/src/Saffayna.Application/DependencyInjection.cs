using Microsoft.Extensions.DependencyInjection; // comes with the AutoMapper package

namespace Saffayna.Application;

public static class DependencyInjection
{
    // Same pattern as AddInfrastructure(connectionString): Api reads the configuration,
    // and this layer receives only the value it needs.
    public static IServiceCollection AddApplication(this IServiceCollection services, string? autoMapperLicenseKey)
    {
        services.AddAutoMapper(
            cfg => cfg.LicenseKey = autoMapperLicenseKey, // null is fine: it works and logs a warning
            typeof(DependencyInjection).Assembly);         // scan this project for Profile classes

        return services;
    }
}