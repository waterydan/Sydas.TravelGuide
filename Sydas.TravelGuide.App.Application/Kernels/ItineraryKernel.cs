using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Sydas.Framework.Core.Utilities;
using Sydas.Framework.DependencyInjection;
using Sydas.Framework.SemanticKernel;

namespace Sydas.TravelGuide.App.Application.Kernels;

[Export]
public class ItineraryKernel
{
    public ItineraryKernel()
    {
        var builder = Kernel.CreateBuilder();
        var plugins = builder.Plugins.AddLiquidPromptsFromDirectory(FileUtils.GetAbsolutePath("Kernels/Prompts"));
        // builder.Plugins.Add(plugins.First());
        var kernel = builder.Build();
        SemanticKernel = kernel;
    }
    
    public Kernel SemanticKernel { get; }
}

// public static class ItineraryKernelExtensions
// {
//     public static IServiceCollection AddItineraryKernel(this IServiceCollection services)
//     {
//         services.AddKeyedTransient<Kernel>(nameof(ItineraryKernel), (provider, o) =>
//         {
//             var builder = Kernel.CreateBuilder();
//             builder.Plugins.AddLiquidPromptsFromDirectory(FileUtils.GetAbsolutePath("Kernels/Prompts"));
//             var kernel = builder.Build();
//             return kernel;
//         });
//         return services;
//     }
// }