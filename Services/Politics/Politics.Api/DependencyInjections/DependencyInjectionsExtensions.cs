using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Politics.Api.Abstractions;
using Politics.Api.Models.Input;

namespace Politics.Api.DependencyInjections;

public static class DependencyInjectionsExtensions
{
    public static void AddPoliticsService(this IServiceCollection services)
    {
        services.AddTransient<IValidator<MkInput>, MkInputValidator>();
        services.AddTransient<IValidator<FactionInput>, FactionInputValidator>();
        services.AddTransient<IValidator<KnessetInput>, KnessetInputValidator>();
        services.AddTransient<IValidator<GovernmentInput>, GovernmentInputValidator>();
        services.AddSingleton<IKnessetApi, PoliticsApi>();
    }
}
