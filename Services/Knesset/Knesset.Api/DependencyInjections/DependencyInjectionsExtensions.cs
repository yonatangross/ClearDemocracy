using Microsoft.Extensions.DependencyInjection;
using KnessetService.Api.Abstractions;

namespace KnessetService.Api.DependencyInjections;

public static class DependencyInjectionsExtensions
{
    public static void AddKnessetService(this IServiceCollection services)
    {
        services.AddSingleton<IKnessetApi, PoliticsApi>();
    }
}
