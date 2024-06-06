using System.ComponentModel.DataAnnotations;

namespace Politics.BL.Models;

public class Government
{
    public int GovId { get; set; }

    [Required]
    [StringLength(255)]
    public string GovName { get; set; }

    public DateTime GovStartDate { get; set; }

    public DateTime? GovFinishDate { get; set; }

    [StringLength(255)]
    public string GovPmImage { get; set; }

    [StringLength(255)]
    public string GovBannerImage { get; set; }

    public bool GovCurrent { get; set; }

    public bool SearchedGov { get; set; }

    [StringLength(255)]
    public string KnessetNames { get; set; }

    public string GovNotes { get; set; }

    // Navigation property
    public ICollection<Minister> Ministers { get; set; }
}
