namespace KnessetService.Api.Models.Input;

public class MkInput
{
    public int MkId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? FactionId { get; set; }
    public string ImagePath { get; set; }
    public string FirstLetter { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Gender { get; set; }
    public int? YearDate { get; set; }
    public string Fax { get; set; }
    public string Facebook { get; set; }
    public string Twitter { get; set; }
    public string Instagram { get; set; }
    public string Youtube { get; set; }
    public bool? IsPresent { get; set; }
    public bool? IsCoalition { get; set; }
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
            Gender = input.Gender,
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
