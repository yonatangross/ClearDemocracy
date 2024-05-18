using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politics.Dal.Models;

[Table("knesset")]
public partial class Knesset
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; }

    [Column("from_date", TypeName = "datetime")]
    public DateTime FromDate { get; set; }

    [Column("to_date", TypeName = "datetime")]
    public DateTime? ToDate { get; set; }

    [Column("is_current")]
    public bool IsCurrent { get; set; }

    [InverseProperty("Knesset")]
    public virtual ICollection<Faction> Factions { get; set; } = new List<Faction>();

    [InverseProperty("Knesset")]
    public virtual ICollection<Minister> Ministers { get; set; } = new List<Minister>();
}
