using System.Text.Json.Serialization;

namespace ClearDemocracy.KnessetService.Api.Models;

public class FactionsRoot
{
    [JsonPropertyName("knessetList")]
    public IList<Knesset> Knessets { get; set; }

    [JsonPropertyName("FactionList")]
    public IList<Faction> Factions { get; set; }
}
