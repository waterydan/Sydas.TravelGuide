using Sydas.TravelGuide.Core.Domain.Abstracts;

namespace Sydas.TravelGuide.Core.Domain.Entities;

public class Attraction : ItineraryDetail
{
    public Attraction(string title, string description, DateTimeOffset visitTime) : base(title, description)
    {
    }
    
}