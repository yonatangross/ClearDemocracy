using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KnessetService.Dal.DependencyInjections;

public static class DependencyInjectionsExtensions
{
    public static void AddKnessetDal(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<KnessetContext>(options =>
        //{
        //    options.UseMySql(
        //        configuration.GetConnectionString("politics"),
        //        ServerVersion.AutoDetect(configuration.GetConnectionString("politics"))
        //    );
        //}, ServiceLifetime.Singleton);

        //services.AddSingleton<IPoliticsDal, PoliticsDal>();
    }
}
