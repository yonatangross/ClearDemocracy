namespace KnessetService.Api.Models.Input;

public class MinisterLastPositionInput
{
    public int ID { get; set; }
    public int TypeID { get; set; }
    public int GO_PositionID { get; set; }
    public int SAN_PositionId { get; set; }
    public string PositionName { get; set; }
    public string Name { get; set; }
    public string MkName { get; set; }
    public int FK_SanID { get; set; }
    public int PosId { get; set; }
    public int? faction_id { get; set; }
    public string FactionName { get; set; }
    public int knesset { get; set; }
    public string KnessetName { get; set; }
    public int GovermentId { get; set; }
    public string GovermentName { get; set; }
    public int Ordinal { get; set; }
    public int Ordinal2 { get; set; }
    public int OrdinalFirst { get; set; }
    public int MinistryId { get; set; }
    public string MinistryName { get; set; }
    public DateTime GovStartDate { get; set; }
    public object GovFinishDate { get; set; }
    public string GovStartDateStr { get; set; }
    public string GovStartDateStr2 { get; set; }
    public object GovFinishDateStr { get; set; }
    public object GovFinishDateStr2 { get; set; }
    public DateTime PositionStratDate { get; set; }
    public object PositionFinishedDate { get; set; }
    public bool IsMK { get; set; }
    public int LU_Gender { get; set; }
    public object Notes { get; set; }
    public int PositionId { get; set; }
    public int RNK { get; set; }
    public int PosGroup { get; set; }
    public string StartDateStr { get; set; }
    public object FinishDateStr { get; set; }
    public int rnk1 { get; set; }
    public string GovGroups { get; set; }
}

public static class MinisterLastPositionInputExtensions
{
    public static BL.Models.Minister ToBlModel(this MinisterLastPositionInput input)
    {
        return new BL.Models.Minister
        {
            Id = input.ID,
            TypeId = input.TypeID,
            GoPositionId = input.GO_PositionID,
            SanPositionId = input.SAN_PositionId,
            PositionName = input.PositionName,
            Name = input.Name,
            MkName = input.MkName,
            FkSanId = input.FK_SanID,
            PosId = input.PosId,
            FactionId = input.faction_id,
            KnessetId = input.knesset,
            GovernmentId = input.GovermentId,
            Ordinal = input.Ordinal,
            MinistryId = input.MinistryId,
            GovStartDate = input.GovStartDate,
            GovFinishDate = input.GovFinishDate as DateTime?,
            PositionStartDate = input.PositionStratDate,
            PositionFinishedDate = input.PositionFinishedDate as DateTime?,
            IsMk = input.IsMK,
            Gender = input.LU_Gender.ToString(),
            Notes = input.Notes?.ToString(),
            PositionId = input.PositionId,
            Rnk = input.RNK,
            PosGroup = input.PosGroup
        };
    }
}
