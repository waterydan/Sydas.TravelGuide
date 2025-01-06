using Sydas.TravelGuide.Core.Domain.Entities;

namespace Sydas.TravelGuide.Core.Domain.Aggregates;

public class ItineraryItem
{
    public ItineraryItem(DateOnly date)
    {
        Date = date;
    }
    
    public DateOnly Date { get; set; }

    public IEnumerable<Attraction> PlannedAttractions { get; }
    
    public IEnumerable<Attraction> SuggestedAttractions { get; }
}