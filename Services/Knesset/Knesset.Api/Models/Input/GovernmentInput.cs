namespace KnessetService.Api.Models.Input;

public class GovernmentInput
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
