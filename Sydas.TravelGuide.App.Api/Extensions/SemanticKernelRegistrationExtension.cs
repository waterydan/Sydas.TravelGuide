using Sydas.Framework.SemanticKernel.Options;
using Sydas.TravelGuide.App.Application.Kernels;

namespace Sydas.TravelGuide.App.Api.Extensions;

public static class SemanticKernelRegistrationExtension
{
    public static void ConfigureSemanticKernel(this WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<OpenAIOptions>()
            .Bind(builder.Configuration.GetSection(nameof(OpenAIOptions)))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        var openAIOptions = builder.Configuration.GetSection(nameof(OpenAIOptions)).Get<OpenAIOptions>()!;
        
        builder.Services.AddItineraryKernel(openAIOptions);
    }
}