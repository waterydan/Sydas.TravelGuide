using Sydas.TravelGuide.Core.Domain.Abstracts;

namespace Sydas.TravelGuide.Core.Domain.Entities;

public class Attraction : ItineraryDetail
{
    public Attraction(string title, string description, DateTimeOffset visitTime) : base(title, description)
    {
    }
    
    public string Destination { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public string Reason { get; set; } = string.Empty;
    
    public string VisitDuration { get; set; } = string.Empty;
}