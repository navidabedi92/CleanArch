using CleanArch.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Persistence;

public static class PersistenceServiceRegisteration
{
    public static IServiceCollection
        AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddDbContext<CADatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CADatabaseConnectionString"));
        });

        return services;
    }
}
