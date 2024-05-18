using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KnessetService.Dal.Models;

[Table("faction")]
[Index("KnessetId", Name = "knesset_id")]
public partial class Faction
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; }

    [Column("knesset_id")]
    public int KnessetId { get; set; }

    [Column("is_partial")]
    public bool IsPartial { get; set; }

    [ForeignKey("KnessetId")]
    [InverseProperty("Factions")]
    public virtual Knesset Knesset { get; set; }

    [InverseProperty("Faction")]
    public virtual ICollection<Minister> Ministers { get; set; } = new List<Minister>();

    [InverseProperty("Faction")]
    public virtual ICollection<Mk> Mks { get; set; } = new List<Mk>();
}
