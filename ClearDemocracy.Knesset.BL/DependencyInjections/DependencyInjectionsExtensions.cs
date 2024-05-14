using ClearDemocracy.Knesset.BL.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ClearDemocracy.Knesset.BL.DependencyInjections;

public static class DependencyInjectionsExtensions
{
    public static void AddKnessetBl(this IServiceCollection services)
    {
        services.AddScoped<IKnessetRetriever, KnessetRetriever>();
        services.AddScoped<IKnessetModifier, KnessetModifier>();
    }
}
