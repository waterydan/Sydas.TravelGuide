using System.ComponentModel;
using Sydas.TravelGuide.Core.Domain.ValueObjects;

namespace Sydas.TravelGuide.App.Api.Dtos.Itinerary;

public class ItinerarySuggestionRequest
{
    [Description("Travel start date")]
    public DateTime DepartDate { get; set; }
    
    [Description("Travel end date")]
    public DateTime ReturnDate { get; set; }
    
    public string Destination { get; set; }
    
    public List<TravelGoal> TravelGoals { get; set; }
}