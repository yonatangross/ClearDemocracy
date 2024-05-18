using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Politics.Dal.Models;

[Table("mk")]
[Index("FactionId", Name = "faction_id")]
public partial class Mk
{
    [Key]
    [Column("mk_id")]
    public int MkId { get; set; }

    [Column("first_name")]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Column("last_name")]
    [StringLength(100)]
    public string LastName { get; set; }

    [Column("faction_id")]
    public int? FactionId { get; set; }

    [Column("image_path")]
    [StringLength(255)]
    public string ImagePath { get; set; }

    [Column("first_letter")]
    [StringLength(1)]
    public string FirstLetter { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; }

    [Column("phone")]
    [StringLength(100)]
    public string Phone { get; set; }

    [Column("gender")]
    [StringLength(15)]
    public string Gender { get; set; }

    [Column("year_date")]
    public int? YearDate { get; set; }

    [Column("fax")]
    [StringLength(255)]
    public string Fax { get; set; }

    [Column("facebook")]
    [StringLength(255)]
    public string Facebook { get; set; }

    [Column("twitter")]
    [StringLength(255)]
    public string Twitter { get; set; }

    [Column("instagram")]
    [StringLength(255)]
    public string Instagram { get; set; }

    [Column("youtube")]
    [StringLength(255)]
    public string Youtube { get; set; }

    [Column("is_present")]
    public bool? IsPresent { get; set; }

    [Column("is_coalition")]
    public bool? IsCoalition { get; set; }

    [Column("website_url")]
    [StringLength(255)]
    public string WebsiteUrl { get; set; }

    [ForeignKey("FactionId")]
    [InverseProperty("Mks")]
    public virtual Faction Faction { get; set; }
}
