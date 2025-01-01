using MediatR;
using Sydas.Framework.AspNetCore.Endpoints;

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
        
        app.MapPost("/itineraries/suggestions", async (int id, IMediator mediator) =>
        {
            // var result = await mediator.Send(new GetOrderDetailsQuery { Id = id });
            // return result != null ? Results.Ok(result) : Results.NotFound();

            return Results.Ok("1");
        });
    }
}