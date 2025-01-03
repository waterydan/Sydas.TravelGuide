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
            var result = await _kernel.SemanticKernel.InvokePromptAsync("ItineraryGenerationPrompt", cancellationToken: cancellationToken);
        }
    }
}