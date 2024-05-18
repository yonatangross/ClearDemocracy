using FluentValidation;
using Politics.BL.Models;
using System.Text.Json.Serialization;

namespace Politics.Api.Models.Input;

public class MkInput
{
    [JsonPropertyName("MkId")]
    public int MkId { get; set; }

    [JsonPropertyName("Firstname")]
    public string FirstName { get; set; }

    [JsonPropertyName("Lastname")]
    public string LastName { get; set; }

    [JsonPropertyName("FactionId")]
    public int? FactionId { get; set; }

    [JsonPropertyName("ImagePath")]
    public string ImagePath { get; set; }

    [JsonPropertyName("FirstLetter")]
    public string FirstLetter { get; set; }

    [JsonPropertyName("Email")]
    public string Email { get; set; }

    [JsonPropertyName("Phone")]
    public string Phone { get; set; }

    [JsonPropertyName("GenderId")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Gender Gender { get; set; }

    [JsonPropertyName("YearDate")]
    public int? YearDate { get; set; }

    [JsonPropertyName("Fax")]
    public string Fax { get; set; }

    [JsonPropertyName("Facebook")]
    public string Facebook { get; set; }

    [JsonPropertyName("Twitter")]
    public string Twitter { get; set; }

    [JsonPropertyName("Instegram")]
    public string Instagram { get; set; }

    [JsonPropertyName("Youtube")]
    public string Youtube { get; set; }

    [JsonPropertyName("IsPresent")]
    public bool? IsPresent { get; set; }

    [JsonPropertyName("IsCoalition")]
    public bool? IsCoalition { get; set; }

    [JsonPropertyName("WebsiteUrl")]
    public string WebsiteUrl { get; set; }
}

public static class MkInputExtensions
{
    public static BL.Models.Mk ToBlModel(this MkInput input)
    {
        return new BL.Models.Mk
        {
            MkId = input.MkId,
            FirstName = input.FirstName,
            LastName = input.LastName,
            FactionId = input.FactionId,
            ImagePath = input.ImagePath,
            FirstLetter = input.FirstLetter,
            Email = input.Email,
            Phone = input.Phone,
            Gender = input.Gender.ToString(),
            YearDate = input.YearDate,
            Fax = input.Fax,
            Facebook = input.Facebook,
            Twitter = input.Twitter,
            Instagram = input.Instagram,
            Youtube = input.Youtube,
            IsPresent = input.IsPresent,
            IsCoalition = input.IsCoalition,
            WebsiteUrl = input.WebsiteUrl
        };
    }
}

public class MkInputValidator : AbstractValidator<MkInput>
{
    public MkInputValidator()
    {
        RuleFor(mk => mk.MkId).NotEmpty().WithMessage("MkId is required.");
        RuleFor(mk => mk.FirstName).NotEmpty().WithMessage("FirstName is required.");
        RuleFor(mk => mk.LastName).NotEmpty().WithMessage("LastName is required.");
        RuleFor(mk => mk.FactionId).NotNull().WithMessage("FactionId is required.");
        RuleFor(mk => mk.ImagePath).NotEmpty().WithMessage("ImagePath is required.");
        RuleFor(mk => mk.FirstLetter).NotEmpty().WithMessage("FirstLetter is required.");
        RuleFor(mk => mk.Email).NotEmpty().EmailAddress().WithMessage("Valid Email is required.");
        RuleFor(mk => mk.Phone).NotEmpty().WithMessage("Phone is required.");
        RuleFor(mk => mk.Gender).IsInEnum().WithMessage("Gender is required and must be a valid enum value.");
        RuleFor(mk => mk.YearDate).NotNull().WithMessage("YearDate is required.");
        RuleFor(mk => mk.Fax);
        RuleFor(mk => mk.Facebook);
        RuleFor(mk => mk.Twitter);
        RuleFor(mk => mk.Instagram);
        RuleFor(mk => mk.Youtube);
        RuleFor(mk => mk.IsPresent).NotNull().WithMessage("IsPresent is required.");
        RuleFor(mk => mk.IsCoalition).NotNull().WithMessage("IsCoalition is required.");
        RuleFor(mk => mk.WebsiteUrl);
    }
}
