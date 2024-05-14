using ClearDemocracy.KnessetService.Abstractions;
using ClearDemocracy.KnessetService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ClearDemocracy.Knesset.BL.DependencyInjections;

public static class DependencyInjectionsExtensions
{
    public static void AddKnessetService(this IServiceCollection services)
    {
        services.AddSingleton<IKnessetApi, KnessetApi>();
    }
}
