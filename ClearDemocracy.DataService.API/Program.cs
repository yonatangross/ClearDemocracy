using ClearDemocracy.KnessetService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClearDemocracy.Politics.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ConfigureServiceRegistration(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        ConfigureMiddleware(app);

        app.Run();
    }

    private static void ConfigureServiceRegistration(IServiceCollection services)
    {
        services.AddControllers();
        // Swagger/OpenAPI support
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        // HTTP client service for external API calls
        services.AddHttpClient<KnessetApi>();
        // Singleton instance for KnessetApi
        services.AddSingleton<KnessetApi>();
        // Default CORS policy configuration
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder => builder.WithOrigins("http://localhost:3000")  // Allowing only a specific origin
                                  .AllowAnyMethod()  // Allows all methods
                                  .AllowAnyHeader()); // Allows all headers
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

        // UseRouting is now implicit in .NET 6+
        // CORS should be configured after routing but before authorization and endpoints
        app.UseCors();

        // Use Authentication and Authorization
        app.UseAuthentication(); // If using authentication ensure this middleware is added
        app.UseAuthorization();

        // Map controllers to endpoints
        app.MapControllers();
    }
}
