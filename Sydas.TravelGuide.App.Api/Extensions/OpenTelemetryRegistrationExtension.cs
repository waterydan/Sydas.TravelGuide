using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Sydas.TravelGuide.App.Api.Extensions;

public static class OpenTelemetryRegistrationExtension
{
    public static WebApplicationBuilder ConfigureOpenTelemetry(this WebApplicationBuilder builder)
    {
        var otb = builder.Services
            .AddOpenTelemetry()
            .ConfigureResource(resourceBuilder => resourceBuilder.AddService("TravelGuideApi"))
            .UseOtlpExporter()
            .WithTracing(providerBuilder =>
            {
                providerBuilder
                    .AddSource("OpenAI.*")
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
            })
            .WithMetrics(providerBuilder =>
            {
                providerBuilder
                    .AddMeter("OpenAI.*")
                    .AddRuntimeInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddAspNetCoreInstrumentation();
                // .AddMeter("Microsoft.SemanticKernel*")
            });

        if (builder.Environment.IsDevelopment())
        {
            otb.WithLogging(providerBuilder => providerBuilder.AddConsoleExporter());
        }

        return builder;
    }
}