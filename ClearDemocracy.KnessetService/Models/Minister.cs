namespace ClearDemocracy.KnessetService.Api.Models;

public class Minister
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
    public string GovFinishDateStr { get; set; }
    public string GovFinishDateStr2 { get; set; }
    public DateTime PositionStratDate { get; set; }
    public DateTime? PositionFinishedDate { get; set; }
    public bool IsMK { get; set; }
    public int LU_Gender { get; set; }
    public object Notes { get; set; }
    public int PositionId { get; set; }
    public int RNK { get; set; }
    public int PosGroup { get; set; }
    public string StartDateStr { get; set; }
    public string FinishDateStr { get; set; }
    public string GovGroups { get; set; }
}