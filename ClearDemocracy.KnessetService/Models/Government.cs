namespace ClearDemocracy.KnessetService.Api.Models;

public class Government
{
    public int GovId { get; set; }
    public string GovName { get; set; }
    public DateTime GovStartDate { get; set; }
    public string GovNamedStartDateStr { get; set; }
    public string GovStartDateStr { get; set; }
    public DateTime? GovFinishDate { get; set; }
    public string GovNamedFinishDateStr { get; set; }
    public string GovFinishDateStr { get; set; }
    public string GovPMImage { get; set; }
    public string GovBannerImage { get; set; }
    public bool GovCurrent { get; set; }
    public bool SearchedGov { get; set; }
    public string KnessetNames { get; set; }
    public string GovNotes { get; set; }
}