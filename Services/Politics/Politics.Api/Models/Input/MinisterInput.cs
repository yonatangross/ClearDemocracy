using FluentValidation;
using Politics.BL.Models;
using System.Text.Json.Serialization;

namespace Politics.Api.Models.Input;

public class MinisterInput
{
    [JsonPropertyName("ID")]
    public int Id { get; set; }

    [JsonPropertyName("TypeID")]
    public int TypeId { get; set; }

    [JsonPropertyName("GO_PositionID")]
    public int GoPositionId { get; set; }

    [JsonPropertyName("SAN_PositionId")]
    public int SanPositionId { get; set; }

    [JsonPropertyName("PositionName")]
    public string PositionName { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("MkName")]
    public string MkName { get; set; }

    [JsonPropertyName("FK_SanID")]
    public int FkSanId { get; set; }

    [JsonPropertyName("PosId")]
    public int PosId { get; set; }

    [JsonPropertyName("faction_id")]
    public int? FactionId { get; set; }

    [JsonPropertyName("knesset")]
    public int Knesset { get; set; }

    [JsonPropertyName("government_id")]
    public int GovernmentId { get; set; }

    [JsonPropertyName("Ordinal")]
    public int Ordinal { get; set; }

    [JsonPropertyName("MinistryId")]
    public int MinistryId { get; set; }

    [JsonPropertyName("GovStartDate")]
    public DateTime GovStartDate { get; set; }

    [JsonPropertyName("GovFinishDate")]
    public DateTime? GovFinishDate { get; set; }

    [JsonPropertyName("PositionStratDate")]
    public DateTime PositionStartDate { get; set; }

    [JsonPropertyName("PositionFinishedDate")]
    public DateTime? PositionFinishedDate { get; set; }

    [JsonPropertyName("IsMK")]
    public bool IsMk { get; set; }

    [JsonPropertyName("LU_Gender")]
    public Gender Gender { get; set; }

    [JsonPropertyName("Notes")]
    public string Notes { get; set; }

    [JsonPropertyName("PositionId")]
    public int PositionId { get; set; }

    [JsonPropertyName("RNK")]
    public int Rnk { get; set; }

    [JsonPropertyName("PosGroup")]
    public int PosGroup { get; set; }
}

public static class MinisterInputExtensions
{
    public static BL.Models.Minister ToBlModel(this MinisterInput input) => new BL.Models.Minister
    {
        Id = input.Id,
        TypeId = input.TypeId,
        GoPositionId = input.GoPositionId,
        SanPositionId = input.SanPositionId,
        PositionName = input.PositionName,
        Name = input.Name,
        MkName = input.MkName,
        FkSanId = input.FkSanId,
        PosId = input.PosId,
        FactionId = input.FactionId,
        KnessetId = input.Knesset,
        GovernmentId = input.GovernmentId,
        Ordinal = input.Ordinal,
        MinistryId = input.MinistryId,
        GovStartDate = input.GovStartDate,
        PositionFinishedDate = input.PositionFinishedDate,
        IsMk = input.IsMk,
        Gender = input.Gender.ToString(),
        Notes = input.Notes
    };
}

public class MinisterInputValidator : AbstractValidator<MinisterInput>
{
    public MinisterInputValidator()
    {
        RuleFor(m => m.Id).GreaterThanOrEqualTo(0).WithMessage("id is required.");
        RuleFor(m => m.TypeId).GreaterThanOrEqualTo(0).WithMessage("type_id is required.");
        RuleFor(m => m.GoPositionId).GreaterThanOrEqualTo(0).WithMessage("go_position_id is required.");
        RuleFor(m => m.SanPositionId).GreaterThanOrEqualTo(0).WithMessage("san_position_id is required.");
        RuleFor(m => m.PositionName).NotEmpty().WithMessage("position_name is required.");
        RuleFor(m => m.Name).NotEmpty().WithMessage("name is required.");
        RuleFor(m => m.MkName).NotEmpty().WithMessage("mk_name is required.");
        RuleFor(m => m.FkSanId).NotEmpty().WithMessage("fk_san_id is required.");
        RuleFor(m => m.PosId).GreaterThanOrEqualTo(0).WithMessage("pos_id is required.");
        RuleFor(m => m.FactionId).GreaterThanOrEqualTo(0).WithMessage("faction_id is required.");
        RuleFor(m => m.Knesset).NotEmpty().WithMessage("knesset is required.");
        RuleFor(m => m.GovernmentId).GreaterThanOrEqualTo(0).WithMessage("government_id is required.");
        RuleFor(m => m.Ordinal).NotEmpty().WithMessage("ordinal is required.");
        RuleFor(m => m.MinistryId).GreaterThanOrEqualTo(0).WithMessage("ministry_id is required.");
        RuleFor(m => m.GovStartDate).NotEmpty().WithMessage("gov_start_date is required.");
        RuleFor(m => m.PositionStartDate).NotEmpty().WithMessage("position_start_date is required.");
        RuleFor(m => m.Gender).IsInEnum().WithMessage("gender is required and must be a valid value.");
        RuleFor(m => m.PositionId).GreaterThanOrEqualTo(0).WithMessage("position_id is required.");
        RuleFor(m => m.Rnk).NotEmpty().WithMessage("rnk is required.");
        RuleFor(m => m.PosGroup).NotEmpty().WithMessage("pos_group is required.");
    }
}
