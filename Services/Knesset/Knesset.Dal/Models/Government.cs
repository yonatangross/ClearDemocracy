using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnessetService.Dal.Models;

[Table("government")]
public partial class Government
{
    [Key]
    [Column("gov_id")]
    public int GovId { get; set; }

    [Required]
    [Column("gov_name")]
    [StringLength(255)]
    public string GovName { get; set; }

    [Column("gov_start_date", TypeName = "datetime")]
    public DateTime GovStartDate { get; set; }

    [Column("gov_finish_date", TypeName = "datetime")]
    public DateTime? GovFinishDate { get; set; }

    [Column("gov_pm_image")]
    [StringLength(255)]
    public string GovPmImage { get; set; }

    [Column("gov_banner_image")]
    [StringLength(255)]
    public string GovBannerImage { get; set; }

    [Column("gov_current", TypeName = "bit(1)")]
    public ulong GovCurrent { get; set; }

    [Column("searched_gov", TypeName = "bit(1)")]
    public ulong SearchedGov { get; set; }

    [Column("knesset_names")]
    [StringLength(255)]
    public string KnessetNames { get; set; }

    [Column("gov_notes", TypeName = "text")]
    public string GovNotes { get; set; }

    [InverseProperty("Government")]
    public virtual ICollection<Minister> Ministers { get; set; } = new List<Minister>();
}
