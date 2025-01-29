using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using MediatR;
using Microsoft.Extensions.Logging;
using Sydas.Framework.SemanticKernel;
using Sydas.TravelGuide.App.Application.Kernels;
using Sydas.TravelGuide.App.Application.Kernels.Prompts;
using Sydas.TravelGuide.Core.Domain.ValueObjects;

namespace Sydas.TravelGuide.App.Application.Commands.Itinerary;

public static class GenerateItinerary
{
    public class Command : IRequest<AttractionSuggestions>
    {
        [Description("Travel start date")]
        public DateTime DepartDate { get; set; } = DateTime.Today;
    
        [Description("Travel end date")]
        public DateTime ReturnDate { get; set; }  = DateTime.Today.AddDays(5);

        [Description("The travel destination")]
        public string Destination { get; set; } = "Tokyo, Japan";
    
        [Description("Travel purposes")]
        public List<TravelGoal> TravelGoals { get; set; } = new() { TravelGoal.Adventure, TravelGoal.Food, TravelGoal.Relaxation };
    }

    public class CommandHandler : IRequestHandler<Command, AttractionSuggestions>
    {
        private readonly ItineraryKernel _kernel;
        private readonly ILogger<CommandHandler> _logger;

        public CommandHandler(ItineraryKernel kernel, ILogger<CommandHandler> logger)
        {
            _kernel = kernel;
            _logger = logger;
        }
        
        public async Task<AttractionSuggestions> Handle(Command request, CancellationToken cancellationToken)
        {
            _logger.LogDebug(request.Dump());
            
            JsonSerializerOptions options = JsonSerializerOptions.Default;
            JsonNode schema = options.GetJsonSchemaAsNode(typeof(AttractionSuggestions));
            Console.WriteLine(schema.ToString());
            var requestJsonMetadata= ClassDescriptor.ConvertClassToText<Command>();
            var responseJsonMetadata= ClassDescriptor.ConvertClassToText<AttractionSuggestions>();
            var result = await _kernel.SemanticKernel.InvokeKernelFunctionFromFileAsync("Kernels/Prompts/AttractionSuggestion.prompt.yaml", new()
            {
                // { "request_metadata", requestJsonMetadata },
                // { "response_metadata", responseJsonMetadata },
                { "json_document", JsonSerializer.Serialize(request, new JsonSerializerOptions(JsonSerializerDefaults.Web)) },
            });
            
            // var function = _kernel.GetKernelFunction("ItineraryGenerationPrompt");
            // var jsonMetadata= ClassDescriptor.ConvertClassToText<Command>();
            // var result = await _kernel.SemanticKernel.InvokeAsync(function, new()
            // {
            //     { "json_metadata", jsonMetadata },
            //     { "json_document", JsonSerializer.Serialize(request, new JsonSerializerOptions(JsonSerializerDefaults.Web)) },
            // }, cancellationToken);
        
            var json = result.GetValue<string>();
            var test = JsonSerializer.Deserialize<AttractionSuggestions>(json);
            return test;
        }
    }
}