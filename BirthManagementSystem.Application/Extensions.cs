using BirthManagementSystem.Application.Commands.Babies.AddBaby;
using BirthManagementSystem.Application.Commands.Babies.UpdateBaby;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BirthManagementSystem.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(executingAssembly);

        services.AddScoped<IValidator<AddBabyCommand>, AddBabyCommandValidation>();
        services.AddScoped<IValidator<UpdateBabyCommand>, UpdateBabyCommandValidation>();

        return services;
    }
}
