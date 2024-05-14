using ClearDemocracy.Knesset.Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClearDemocracy.Knesset.Dal.DependencyInjections
{
    public static class DependencyInjectionsExtensions
    {
        public static void AddKnessetDal(this IServiceCollection services, IConfigurationManager configuration)
        {
     
        }
    }
}
