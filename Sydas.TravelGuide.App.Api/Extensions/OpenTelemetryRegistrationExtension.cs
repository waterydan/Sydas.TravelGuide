using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Sydas.TravelGuide.App.Api.Extensions;

public static class OpenTelemetryRegistrationExtension
{
    public static WebApplicationBuilder ConfigureOpenTelemetry(this WebApplicationBuilder builder)
    {
        var otb = builder.Services.AddOpenTelemetry().UseOtlpExporter()
            .WithTracing(providerBuilder =>
            {
                providerBuilder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
            })
            .WithMetrics(providerBuilder =>
            {
                providerBuilder
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