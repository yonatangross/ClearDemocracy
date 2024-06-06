using Aspire.ServiceDefaults;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Politics.Api;
using Politics.Api.DependencyInjections;
using Politics.Api.Options;
using Politics.BL.DependencyInjections;
using Politics.Dal.DependencyInjections;

namespace WebApi.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.
        ConfigureServiceRegistration(builder.Services, builder.Configuration);

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        ConfigureMiddleware(app);

        app.Run();
    }

    private static void ConfigureServiceRegistration(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers();
        // Swagger/OpenAPI support
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.Configure<PoliticsQueryOptions>(configuration.GetSection("PoliticsQueryOptions"));
        services.AddOptions<PoliticsQueryOptions>();
        services.AddPoliticsDal(configuration);
        services.AddPoliticsBl();
        services.AddPoliticsService();
        // HTTP client service for external API calls
        services.AddHttpClient<PoliticsApi>();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder => builder.WithOrigins("http://localhost:3000")  // Allowing only a specific origin
                                  .AllowAnyMethod()  // Allows all methods
                                  .AllowAnyHeader()  // Allows all headers
                                  .AllowCredentials()); // Allow credentials
        });
    }

    private static void ConfigureMiddleware(WebApplication app)
    {
        // Serve Swagger UI in development mode
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Redirection to HTTPS
        app.UseHttpsRedirection();

        // CORS should be configured after routing but before authorization and endpoints
        app.UseRouting();
        app.UseCors();

        // Use Authentication and Authorization
        app.UseAuthentication(); // If using authentication ensure this middleware is added
        app.UseAuthorization();

        // Map controllers to endpoints
        app.MapControllers();
    }
}
