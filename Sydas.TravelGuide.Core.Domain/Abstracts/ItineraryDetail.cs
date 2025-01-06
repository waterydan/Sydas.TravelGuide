namespace Sydas.TravelGuide.Core.Domain.Abstracts;

public abstract class ItineraryDetail
{
    protected ItineraryDetail(string title, string description)
    {
        Title = title;
        Description = description;
    }
    
    public string Title { get; protected set; }
    
    public string Description { get; protected set; }
    
    public bool SuggestionOnly { get; protected set; }

}