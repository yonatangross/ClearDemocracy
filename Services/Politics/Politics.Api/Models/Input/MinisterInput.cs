namespace Politics.Api.Models.Input;

public class MinisterInput
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
    public int knesset { get; set; }
    public int GovermentId { get; set; }
    public int Ordinal { get; set; }
    public int MinistryId { get; set; }
    public DateTime GovStartDate { get; set; }
    public DateTime? PositionFinishedDate { get; set; }
    public bool IsMK { get; set; }
    public string Gender { get; set; }
    public string Notes { get; set; }
}

public static class MinisterInputExtensions
{
    public static BL.Models.Minister ToBlModel(this MinisterInput input)
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
            PositionFinishedDate = input.PositionFinishedDate,
            IsMk = input.IsMK,
            Gender = input.Gender,
            Notes = input.Notes
        };
    }
}
