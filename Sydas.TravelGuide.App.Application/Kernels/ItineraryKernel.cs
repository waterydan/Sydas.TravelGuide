using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Sydas.Framework.Core.Utilities;
using Sydas.Framework.DependencyInjection;
using Sydas.Framework.SemanticKernel;

namespace Sydas.TravelGuide.App.Application.Kernels;

[Export]
public class ItineraryKernel
{
    KernelPluginCollection _pluginCollection = [];
    
    public ItineraryKernel()
    {
        // var kernelFunction = KernelFunctionFactory.CreateFromPrompt("");
        // KernelPluginCollection pluginCollection = [];
        // pluginCollection.Add;
        // pluginCollection.Add();.AddFromObject(sp.GetRequiredService<MyTimePlugin>());
        // pluginCollection.AddFromObject(sp.GetRequiredService<MyAlarmPlugin>());
        // pluginCollection.AddFromObject(sp.GetRequiredKeyedService<MyLightPlugin>("OfficeLight"), "OfficeLight");
        // pluginCollection.AddFromObject(sp.GetRequiredKeyedService<MyLightPlugin>("PorchLight"), "PorchLight");
    }
}

public static class ItineraryKernelExtensions
{
    public static IServiceCollection AddItineraryKernel(this IServiceCollection services)
    {
        services.AddKeyedTransient<Kernel>(nameof(ItineraryKernel), (provider, o) =>
        {
            var builder = Kernel.CreateBuilder();
            builder.Plugins.AddLiquidPromptsFromDirectory(FileUtils.GetAbsolutePath("Kernels/Prompts"));
            var kernel = builder.Build();
            return kernel;
        });
        return services;
    }
}