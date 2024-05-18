using System.Text.Json.Serialization;

namespace KnessetService.Api.Models.Input;

public class GovernmentRoot
{
    [JsonPropertyName("GovermentsNames")]
    public List<GovernmentInput> GovermentsNames { get; set; }

    [JsonPropertyName("GovermentPositions")]
    public List<MinisterInput> Ministers { get; set; }

    [JsonPropertyName("GovermentPositionsLast")]
    public List<MinisterLastPositionInput> MinisterLastPositions { get; set; }

    public List<object> GovermentDocs { get; set; }
    public List<object> GovermentEmbededVideos { get; set; }
}

public static class GovernmentRootExtensions
{
    public static IList<BL.Models.Government> ToBlModels(this List<GovernmentInput> inputs)
    {
        var result = new List<BL.Models.Government>();
        foreach (var input in inputs)
        {
            result.Add(input.ToBlModel());
        }
        return result;
    }

    public static IList<BL.Models.Minister> ToBlModels(this List<MinisterInput> inputs)
    {
        var result = new List<BL.Models.Minister>();
        foreach (var input in inputs)
        {
            result.Add(input.ToBlModel());
        }
        return result;
    }

    // Define the conversion for MinisterLastPositionInput if required
}
