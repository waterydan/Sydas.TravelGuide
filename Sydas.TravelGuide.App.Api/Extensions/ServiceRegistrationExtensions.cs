using System.Reflection;
using Sydas.Framework.AspNetCore.Mediator;
using Sydas.Framework.DependencyInjection;
using Sydas.TravelGuide.App.Application.Commands.Itinerary;

namespace Sydas.TravelGuide.App.Api.Extensions;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GenerateItinerary).Assembly);
            cfg.AddOpenBehavior(typeof(RequestLoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        services.AddServicesFromAssemblies();

        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddDbContext<AppDbContext>(options =>
        //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        // services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}