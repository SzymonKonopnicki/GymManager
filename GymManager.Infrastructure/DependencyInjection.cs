using GymManager.Application.Common.Interfaces;
using GymManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("DefualtConnection");

        service.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging();
        });
        return service;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {

        return app;
    }
}

