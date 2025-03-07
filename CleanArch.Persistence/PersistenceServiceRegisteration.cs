using CleanArch.Application.Contracts.Persistence;
using CleanArch.Domain;
using CleanArch.Persistence.DatabaseContext;
using CleanArch.Persistence.Repositories;
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

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

        return services;
    }
}
