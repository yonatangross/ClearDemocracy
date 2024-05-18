using FluentValidation;
using System.Text.Json.Serialization;

namespace Politics.Api.Models.Input;

public class GovernmentInput
{
    [JsonPropertyName("GovId")]
    public int GovId { get; set; }

    [JsonPropertyName("GovName")]
    public string GovName { get; set; }

    [JsonPropertyName("GovStartDate")]
    public DateTime GovStartDate { get; set; }

    [JsonPropertyName("GovNamedStartDateStr")]
    public string GovNamedStartDateStr { get; set; }

    [JsonPropertyName("GovStartDateStr")]
    public string GovStartDateStr { get; set; }

    [JsonPropertyName("GovFinishDate")]
    public DateTime? GovFinishDate { get; set; }

    [JsonPropertyName("GovNamedFinishDateStr")]
    public string GovNamedFinishDateStr { get; set; }

    [JsonPropertyName("GovFinishDateStr")]
    public string GovFinishDateStr { get; set; }

    [JsonPropertyName("GovPMImage")]
    public string GovPMImage { get; set; }

    [JsonPropertyName("GovBannerImage")]
    public string GovBannerImage { get; set; }

    [JsonPropertyName("GovCurrent")]
    public bool GovCurrent { get; set; }

    [JsonPropertyName("SearchedGov")]
    public bool SearchedGov { get; set; }

    [JsonPropertyName("KnessetNames")]
    public string KnessetNames { get; set; }

    [JsonPropertyName("GovNotes")]
    public string GovNotes { get; set; }
}
public static class GovernmentInputExtensions
{
    public static BL.Models.Government ToBlModel(this GovernmentInput input)
    {
        return new BL.Models.Government
        {
            GovId = input.GovId,
            GovName = input.GovName,
            GovStartDate = input.GovStartDate,
            GovFinishDate = input.GovFinishDate,
            GovPmImage = input.GovPMImage,
            GovBannerImage = input.GovBannerImage,
            GovCurrent = input.GovCurrent,
            SearchedGov = input.SearchedGov,
            KnessetNames = input.KnessetNames,
            GovNotes = input.GovNotes
        };
    }
}
public class GovernmentInputValidator : AbstractValidator<GovernmentInput>
{
    public GovernmentInputValidator()
    {
        RuleFor(g => g.GovId).GreaterThanOrEqualTo(0).WithMessage("GovId is required.");
        RuleFor(g => g.GovName).NotEmpty().WithMessage("GovName is required.");
        RuleFor(g => g.GovStartDate).NotEmpty().WithMessage("GovStartDate is required.");
        RuleFor(g => g.GovCurrent).NotNull().WithMessage("GovCurrent is required.");
        RuleFor(g => g.SearchedGov).NotNull().WithMessage("SearchedGov is required.");
    }
}
