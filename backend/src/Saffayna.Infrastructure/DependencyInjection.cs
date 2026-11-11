using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Saffayna.Infrastructure.Persistence;

namespace Saffayna.Infrastructure;

public static class DependencyInjection
{
    // One method that the Api calls to plug in everything from Infrastructure.
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, string connectionString)
    {
        // "Use AppDbContext, and connect to PostgreSQL with this connection string."
        services.AddDbContext<AppDbContext>(o => o.UseNpgsql(connectionString));
        return services;
    }
}