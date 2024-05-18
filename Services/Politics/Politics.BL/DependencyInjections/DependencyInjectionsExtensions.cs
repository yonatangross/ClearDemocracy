using Microsoft.Extensions.DependencyInjection;
using Politics.BL.Abstractions;

namespace Politics.BL.DependencyInjections;

public static class DependencyInjectionsExtensions
{
    public static void AddPoliticsBl(this IServiceCollection services)
    {
        services.AddScoped<IPoliticsRetriever, PoliticsRetriever>();
        services.AddScoped<IPoliticsModifier, PoliticsModifier>();
    }
}
