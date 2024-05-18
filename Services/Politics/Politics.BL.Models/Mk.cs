using System.ComponentModel.DataAnnotations;

namespace Politics.BL.Models;

public class Mk
{
    public int MkId { get; set; }

    [StringLength(100)]
    public string FirstName { get; set; }

    [StringLength(100)]
    public string LastName { get; set; }

    public int? FactionId { get; set; }

    [StringLength(255)]
    public string ImagePath { get; set; }

    [StringLength(1)]
    public string FirstLetter { get; set; }

    [StringLength(255)]
    public string Email { get; set; }

    [StringLength(100)]
    public string Phone { get; set; }

    [StringLength(15)]
    public string Gender { get; set; }

    public int? YearDate { get; set; }

    [StringLength(255)]
    public string Fax { get; set; }

    [StringLength(255)]
    public string Facebook { get; set; }

    [StringLength(255)]
    public string Twitter { get; set; }

    [StringLength(255)]
    public string Instagram { get; set; }

    [StringLength(255)]
    public string Youtube { get; set; }

    public bool? IsPresent { get; set; }

    public bool? IsCoalition { get; set; }

    [StringLength(255)]
    public string WebsiteUrl { get; set; }
}
