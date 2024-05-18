using FluentValidation;
using System.Text.Json.Serialization;

namespace Politics.Api.Models.Input;

public class KnessetInput
{
    [JsonPropertyName("ID")]
    public int Id { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("FromDate")]
    public DateTime FromDate { get; set; }

    [JsonPropertyName("ToDate")]
    public DateTime? ToDate { get; set; }

    [JsonPropertyName("IsCurrent")]
    public bool IsCurrent { get; set; }
}

public static class KnessetInputExtensions
{
    public static BL.Models.Knesset ToBlModel(this KnessetInput input)
    {
        return new BL.Models.Knesset
        {
            Id = input.Id,
            Name = input.Name,
            FromDate = input.FromDate,
            ToDate = input.ToDate,
            IsCurrent = input.IsCurrent
        };
    }
}

public class KnessetInputValidator : AbstractValidator<KnessetInput>
{
    public KnessetInputValidator()
    {
        RuleFor(knesset => knesset.Id).GreaterThanOrEqualTo(0).WithMessage("ID is required.");
        RuleFor(knesset => knesset.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(knesset => knesset.FromDate).NotEmpty().WithMessage("FromDate is required.");
        RuleFor(knesset => knesset.IsCurrent).NotNull().WithMessage("IsCurrent is required.");
    }
}
