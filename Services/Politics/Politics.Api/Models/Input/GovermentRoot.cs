using FluentValidation;
using System.Text.Json.Serialization;

namespace Politics.Api.Models.Input;

public class GovernmentRoot
{
    [JsonPropertyName("GovermentsNames")]
    public List<GovernmentInput> GovermentsNames { get; set; }

    [JsonPropertyName("GovermentPositions")]
    public List<MinisterInput> Ministers { get; set; }

    [JsonPropertyName("GovermentPositionsLast")]
    public List<MinisterLastPositionInput> MinisterLastPositions { get; set; }

    [JsonPropertyName("GovermentDocs")]
    public List<object> GovermentDocs { get; set; }

    [JsonPropertyName("GovermentEmbededVideos")]
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

public class GovernmentRootValidator : AbstractValidator<GovernmentRoot>
{
    public GovernmentRootValidator()
    {
        RuleForEach(g => g.GovermentsNames).SetValidator(new GovernmentInputValidator());
        RuleForEach(g => g.Ministers).SetValidator(new MinisterInputValidator());
        RuleForEach(g => g.MinisterLastPositions).SetValidator(new MinisterLastPositionInputValidator());
    }
}