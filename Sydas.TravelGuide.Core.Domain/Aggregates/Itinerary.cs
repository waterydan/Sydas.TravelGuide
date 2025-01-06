using Sydas.TravelGuide.Core.Domain.ValueObjects;

namespace Sydas.TravelGuide.Core.Domain.Aggregates;

public class Itinerary
{
    private readonly List<ItineraryItem> _itineraryItems = new();
    private readonly List<TravelGoal> _travelGoals = new();
    
    public Itinerary(string title, string description, List<TravelGoal> travelGoals)
    {
        Title = title;
        Description = description;
        _travelGoals = travelGoals;
    }

    public Guid Id { get; } = Guid.CreateVersion7();

    public string Title { get; }
    
    public string Description { get; }
    
    public TimeSpan UtcOffset { get; } = TimeSpan.Zero;

    public IReadOnlyCollection<ItineraryItem> Items => _itineraryItems;
    
    public IReadOnlyCollection<TravelGoal> TravelGoals => _travelGoals;

    public void AddItem(ItineraryItem itineraryItem)
    {
        if (itineraryItem == null) throw new ArgumentNullException(nameof(itineraryItem));
        
        _itineraryItems.Add(itineraryItem);
    }
    
    public void RemoveItem(ItineraryItem itineraryItem)
    {
        if (itineraryItem == null) throw new ArgumentNullException(nameof(itineraryItem));
        
        _itineraryItems.Add(itineraryItem);
    }

    #region TravelGoal

    public void AddTravelGoal(TravelGoal travelGoal)
    {
        _travelGoals.Add(travelGoal);
    }
    
    public void RemoveTravelGoal(TravelGoal travelGoal)
    {
        _travelGoals.Remove(travelGoal);
    }
    
    public void ClearTravelGoal(TravelGoal travelGoal)
    {
        _travelGoals.Clear();
    }
    
    #endregion
    
}