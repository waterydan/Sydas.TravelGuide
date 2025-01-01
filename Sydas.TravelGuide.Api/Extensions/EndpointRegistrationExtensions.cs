namespace Sydas.TravelGuide.Api.Extensions;

public static class EndpointRegistrationExtensions
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        // OrderEndpoints.Map(app);
        return app;
    }
}