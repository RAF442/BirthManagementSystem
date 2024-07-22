using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Infrastructure.Context;
using BirthManagementSystem.Infrastructure.Repositoires;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BirthManagementSystem.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IBabyReadOnlyRepository, BabyReadOnlyRepository>();
        services.AddScoped<IBabyRepository, BabyRepository>();

        services.AddScoped<IApgarScoreRepository, ApgarScoreRepository>();

        services.AddDbContext<BirthManagementSystemDbContext>(ctx => ctx.UseSqlServer(configuration.GetConnectionString("BirthManagementSystemCS")));

        return services;
    }
}
