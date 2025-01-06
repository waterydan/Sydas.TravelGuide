using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Sydas.TravelGuide.App.Api.Extensions;

public static class OpenTelemetryRegistrationExtension
{
    public static WebApplicationBuilder ConfigureOpenTelemetry(this WebApplicationBuilder builder)
    {
       builder.Services.AddOpenTelemetry()
            .WithTracing(tracerProviderBuilder =>
            {
                tracerProviderBuilder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .SetResourceBuilder(
                        ResourceBuilder.CreateDefault()
                            .AddService(builder.Environment.ApplicationName))
                    .AddConsoleExporter(); // Or other exporters
            });

        builder.Logging.AddOpenTelemetry(options =>
        {
            options.IncludeScopes = true;
            options.ParseStateValues = true;
            options.IncludeFormattedMessage = true;
            options.AddConsoleExporter(); // Or other exporters
        });

        return builder;
    }
}