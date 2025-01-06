using System.ComponentModel;

namespace Sydas.TravelGuide.App.Application.Kernels.Prompts;

public class AttractionSuggestion
{
    [Description("The name or location of the attraction being suggested. This could be the specific attraction name (e.g., “Osaka Castle”) or a general area (e.g., “Dotonbori, Osaka”).")]
    public string Destination { get; set; } = string.Empty;
    
    [Description("TA brief overview of the attraction, highlighting its key features or unique aspects. For example, it might describe what the attraction is, its historical or cultural significance, or any unique activities available.")]
    public string Description { get; set; } = string.Empty;
    
    [Description("An explanation of why this attraction is recommended, tailored to the traveler’s preferences or interests.")]
    public string Reason { get; set; } = string.Empty;
    
    [Description("A recommended amount of time to spend at the attraction. This is to be represented in short form, such as 2h or 30m")]
    public string SuggestedDuration { get; set; } = string.Empty;
}