using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ClearDemocracy.KnessetService.Api.Abstractions;
using ClearDemocracy.KnessetService.Api;

namespace ClearDemocracy.KnessetService.Api.DependencyInjections;

public static class DependencyInjectionsExtensions
{
    public static void AddKnessetService(this IServiceCollection services)
    {
        services.AddSingleton<IKnessetApi, KnessetApi>();
    }
}
