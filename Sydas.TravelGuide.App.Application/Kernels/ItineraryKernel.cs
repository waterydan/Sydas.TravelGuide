using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Sydas.Framework.Core.Utilities;
using Sydas.Framework.DependencyInjection;
using Sydas.Framework.SemanticKernel;
using Sydas.Framework.SemanticKernel.Options;

namespace Sydas.TravelGuide.App.Application.Kernels;

public class ItineraryKernel
{
    private readonly IEnumerable<KernelFunction> _kernelFunctions;
    
    public ItineraryKernel(OpenAIOptions openAIOptions)
    {
        var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(openAIOptions.ChatModelId, openAIOptions.ApiKey);
        _kernelFunctions = builder.Plugins.AddLiquidPromptsFromDirectory(FileUtils.GetAbsolutePath("Kernels/Prompts"));
        SemanticKernel = builder.Build();
    }
    
    public Kernel SemanticKernel { get; }

    public KernelFunction GetKernelFunction(string name)
    {
        return _kernelFunctions.First(function => function.Name == name);
    }
}

public static class ItineraryKernelExtensions
{
    public static IServiceCollection AddItineraryKernel(this IServiceCollection services, OpenAIOptions openAIOptions)
    {
        services.AddScoped<ItineraryKernel>(_ =>
        {
            // var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(openAIOptions.ChatModelId, openAIOptions.ApiKey);
            // builder.Plugins.AddLiquidPromptsFromDirectory(FileUtils.GetAbsolutePath("Kernels/Prompts"));
            // var kernel = builder.Build();
            // return kernel;
            return new ItineraryKernel(openAIOptions);
        });
        return services;
    }
}