using FluentValidation;
using Politics.BL.Models;
using System.Text.Json.Serialization;

namespace Politics.Api.Models.Input;

public class MinisterLastPositionInput
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("type_id")]
    public int TypeId { get; set; }

    [JsonPropertyName("go_position_id")]
    public int GoPositionId { get; set; }

    [JsonPropertyName("san_position_id")]
    public int SanPositionId { get; set; }

    [JsonPropertyName("position_name")]
    public string PositionName { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("mk_name")]
    public string MkName { get; set; }

    [JsonPropertyName("fk_san_id")]
    public int FkSanId { get; set; }

    [JsonPropertyName("pos_id")]
    public int PosId { get; set; }

    [JsonPropertyName("faction_id")]
    public int? FactionId { get; set; }

    [JsonPropertyName("knesset")]
    public int Knesset { get; set; }

    [JsonPropertyName("government_id")]
    public int GovernmentId { get; set; }

    [JsonPropertyName("ordinal")]
    public int Ordinal { get; set; }

    [JsonPropertyName("ministry_id")]
    public int MinistryId { get; set; }

    [JsonPropertyName("gov_start_date")]
    public DateTime GovStartDate { get; set; }

    [JsonPropertyName("gov_finish_date")]
    public DateTime? GovFinishDate { get; set; }

    [JsonPropertyName("position_start_date")]
    public DateTime PositionStartDate { get; set; }

    [JsonPropertyName("position_finished_date")]
    public DateTime? PositionFinishedDate { get; set; }

    [JsonPropertyName("is_mk")]
    public bool IsMk { get; set; }

    [JsonPropertyName("gender")]
    public Gender Gender { get; set; }

    [JsonPropertyName("notes")]
    public string Notes { get; set; }

    [JsonPropertyName("position_id")]
    public int PositionId { get; set; }

    [JsonPropertyName("rnk")]
    public int Rnk { get; set; }

    [JsonPropertyName("pos_group")]
    public int PosGroup { get; set; }
}

public static class MinisterLastPositionInputExtensions
{
    public static Politics.BL.Models.Minister ToBlModel(this MinisterLastPositionInput input)
    {
        return new Politics.BL.Models.Minister
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
            GovFinishDate = input.GovFinishDate as DateTime?,
            PositionStartDate = input.PositionStartDate,
            PositionFinishedDate = input.PositionFinishedDate as DateTime?,
            IsMk = input.IsMk,
            Gender = input.Gender.ToString(),
            Notes = input.Notes?.ToString(),
            PositionId = input.PositionId,
            Rnk = input.Rnk,
            PosGroup = input.PosGroup
        };
    }
}

public class MinisterLastPositionInputValidator : AbstractValidator<MinisterLastPositionInput>
{
    public MinisterLastPositionInputValidator()
    {
        RuleFor(m => m.Id).NotEmpty().WithMessage("id is required.");
        RuleFor(m => m.TypeId).NotEmpty().WithMessage("type_id is required.");
        RuleFor(m => m.GoPositionId).NotEmpty().WithMessage("go_position_id is required.");
        RuleFor(m => m.SanPositionId).NotEmpty().WithMessage("san_position_id is required.");
        RuleFor(m => m.PositionName).NotEmpty().WithMessage("position_name is required.");
        RuleFor(m => m.Name).NotEmpty().WithMessage("name is required.");
        RuleFor(m => m.MkName).NotEmpty().WithMessage("mk_name is required.");
        RuleFor(m => m.FkSanId).NotEmpty().WithMessage("fk_san_id is required.");
        RuleFor(m => m.PosId).NotEmpty().WithMessage("pos_id is required.");
        RuleFor(m => m.FactionId).NotNull().WithMessage("faction_id is required.");
        RuleFor(m => m.Knesset).NotEmpty().WithMessage("knesset is required.");
        RuleFor(m => m.GovernmentId).NotEmpty().WithMessage("government_id is required.");
        RuleFor(m => m.Ordinal).NotEmpty().WithMessage("ordinal is required.");
        RuleFor(m => m.MinistryId).NotEmpty().WithMessage("ministry_id is required.");
        RuleFor(m => m.GovStartDate).NotEmpty().WithMessage("gov_start_date is required.");
        RuleFor(m => m.PositionStartDate).NotEmpty().WithMessage("position_start_date is required.");
        RuleFor(m => m.Gender).IsInEnum().WithMessage("gender is required and must be a valid value.");
        RuleFor(m => m.PositionId).NotEmpty().WithMessage("position_id is required.");
        RuleFor(m => m.Rnk).NotEmpty().WithMessage("rnk is required.");
        RuleFor(m => m.PosGroup).NotEmpty().WithMessage("pos_group is required.");
    }
}



