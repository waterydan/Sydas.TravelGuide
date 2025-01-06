using System.Text.Json.Serialization;

namespace Sydas.TravelGuide.Core.Domain.ValueObjects;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TravelGoal
{
    Cultural,
    Educational,
    Relaxation,
    Adventure,
    Wilderness,
    Shopping,
    Food,
    Family,
    Romantic,
    Festival
}