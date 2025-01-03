using MediatR;
using Microsoft.SemanticKernel;
using Sydas.TravelGuide.App.Application.Kernels;

namespace Sydas.TravelGuide.App.Application.Commands.Itinerary;

public static class GenerateItinerary
{
    public class Command : IRequest
    {
    }

    public class CommandHandler : IRequestHandler<Command>
    {
        private readonly ItineraryKernel _kernel;

        public CommandHandler(ItineraryKernel kernel)
        {
            _kernel = kernel;
        }
        
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var function = _kernel.GetKernelFunction("ItineraryGenerationPrompt");
            var result = await _kernel.SemanticKernel.InvokeAsync(function, new()
            {
                { "customer_name", "John Doe" },
                { "destination", "Tokyo, Japan" },
                { "from_date", "2025-02-04" },
                { "to_date", "2025-02-08" }
            }, cancellationToken);
        }
    }
}