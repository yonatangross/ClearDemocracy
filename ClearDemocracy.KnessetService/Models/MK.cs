namespace ClearDemocracy.KnessetService.Models;

public class MK
{
    public int MkId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int FactionId { get; set; }
    public string FactionName { get; set; }
    public string ImagePath { get; set; }
    public string FirstLetter { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int GenderId { get; set; }
    public int YearDate { get; set; }
    public string Fax { get; set; }
    public string Facebook { get; set; }
    public string Twitter { get; set; }
    public string Instagram { get; set; }
    public string Youtube { get; set; }
    public bool IsPresent { get; set; }
    public bool IsCoalition { get; set; }
    public string WebsiteUrl { get; set; }
}
