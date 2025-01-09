using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Sydas.TravelGuide.App.Api.Extensions;

public static class OpenTelemetryRegistrationExtension
{
    public static WebApplicationBuilder ConfigureOpenTelemetry(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenTelemetry()
            .WithTracing(providerBuilder =>
            {
                providerBuilder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter()
                    .AddConsoleExporter();
            })
            .WithMetrics(providerBuilder =>
            {
                providerBuilder
                    .AddRuntimeInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddAspNetCoreInstrumentation()
                    // .AddMeter("Microsoft.SemanticKernel*")
                    .AddOtlpExporter();
            })
            .WithLogging(providerBuilder =>
            {
                providerBuilder
                    .AddOtlpExporter()
                    .AddConsoleExporter();
            });

        return builder;
    }
}