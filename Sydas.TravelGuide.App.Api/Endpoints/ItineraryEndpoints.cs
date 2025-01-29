using MediatR;
using Sydas.Framework.AspNetCore.Endpoints;
using Sydas.TravelGuide.App.Application.Commands.Itinerary;

namespace Sydas.TravelGuide.App.Api.Endpoints;

public class ItineraryEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("/itineraries/{id}", async (int id, IMediator mediator) =>
        {
            // var result = await mediator.Send(new GetOrderDetailsQuery { Id = id });
            // return result != null ? Results.Ok(result) : Results.NotFound();

            return Results.Ok("1");
        });
        
        app.MapPost("/itineraries/suggestions", async (IMediator mediator) =>
        {
            // var result = await mediator.Send(new GetOrderDetailsQuery { Id = id });
            // return result != null ? Results.Ok(result) : Results.NotFound();
            
            var result = await mediator.Send(new GenerateItinerary.Command());
            return Results.Ok(result);
        });
    }
}