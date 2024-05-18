using FluentValidation;
using System.Text.Json.Serialization;

namespace Politics.Api.Models.Input;

public class FactionInput
{
    [JsonPropertyName("ID")]
    public int Id { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("KnessetID")]
    public string KnessetId { get; set; }

    [JsonPropertyName("IsPartial")]
    public bool IsPartial { get; set; }
}

public static class FactionInputExtensions
{
    public static BL.Models.Faction ToBlModel(this FactionInput input)
    {
        return new BL.Models.Faction
        {
            Id = input.Id,
            Name = input.Name,
            KnessetId = int.Parse(input.KnessetId),
            IsPartial = input.IsPartial
        };
    }
}

public class FactionInputValidator : AbstractValidator<FactionInput>
{
    public FactionInputValidator()
    {
        RuleFor(faction => faction.Id).GreaterThanOrEqualTo(0).WithMessage("ID is required.");
        RuleFor(faction => faction.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(faction => int.Parse(faction.KnessetId)).GreaterThanOrEqualTo(0).WithMessage("KnessetID is required.");
        RuleFor(faction => faction.IsPartial).NotNull().WithMessage("IsPartial is required.");
    }
}
