using System.Text.Json.Serialization;

namespace Politics.Api.Models.Input;

public class FactionsRoot
{
    [JsonPropertyName("knessetList")]
    public IList<KnessetInput> Knessets { get; set; }

    [JsonPropertyName("FactionList")]
    public IList<FactionInput> Factions { get; set; }
}

public static class FactionsRootExtensions
{
    public static IList<BL.Models.Knesset> ToBlModels(this IList<KnessetInput> inputs)
    {
        var result = new List<BL.Models.Knesset>();
        foreach (var input in inputs)
        {
            result.Add(input.ToBlModel());
        }
        return result;
    }

    public static IList<BL.Models.Faction> ToBlModels(this IList<FactionInput> inputs)
    {
        var result = new List<BL.Models.Faction>();
        foreach (var input in inputs)
        {
            result.Add(input.ToBlModel());
        }
        return result;
    }
}
