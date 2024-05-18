using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Politics.Dal.Abstractions;
using Politics.Dal.Context;

namespace Politics.Dal.DependencyInjections;

public static class DependencyInjectionsExtensions
{
    public static void AddPoliticsDal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PoliticsContext>(options =>
        {
            options.UseMySql(
                configuration.GetConnectionString("politics"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("politics"))
            );
        }, ServiceLifetime.Singleton);

        services.AddSingleton<IPoliticsDal, PoliticsDal>();
    }
}
