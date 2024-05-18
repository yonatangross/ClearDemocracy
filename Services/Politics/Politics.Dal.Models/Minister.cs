using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Politics.Dal.Models;

[Table("minister")]
[Index("FactionId", Name = "faction_id")]
[Index("FkSanId", Name = "fk_san_id")]
[Index("GovernmentId", Name = "government_id")]
[Index("KnessetId", Name = "knesset_id")]
public partial class Minister
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("type_id")]
    public int TypeId { get; set; }

    [Column("go_position_id")]
    public int GoPositionId { get; set; }

    [Column("san_position_id")]
    public int SanPositionId { get; set; }

    [Required]
    [Column("position_name")]
    [StringLength(255)]
    public string PositionName { get; set; }

    [Required]
    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [Column("mk_name")]
    [StringLength(255)]
    public string MkName { get; set; }

    [Column("fk_san_id")]
    public int FkSanId { get; set; }

    [Column("pos_id")]
    public int PosId { get; set; }

    [Column("faction_id")]
    public int? FactionId { get; set; }

    [Column("knesset_id")]
    public int KnessetId { get; set; }

    [Column("government_id")]
    public int GovernmentId { get; set; }

    [Column("ordinal")]
    public int Ordinal { get; set; }

    [Column("ministry_id")]
    public int MinistryId { get; set; }

    [Column("gov_start_date", TypeName = "datetime")]
    public DateTime GovStartDate { get; set; }

    [Column("gov_finish_date", TypeName = "datetime")]
    public DateTime? GovFinishDate { get; set; }

    [Column("position_start_date", TypeName = "datetime")]
    public DateTime PositionStartDate { get; set; }

    [Column("position_finished_date", TypeName = "datetime")]
    public DateTime? PositionFinishedDate { get; set; }

    [Column("is_mk", TypeName = "bit(1)")]
    public ulong IsMk { get; set; }

    [Required]
    [Column("gender")]
    [StringLength(15)]
    public string Gender { get; set; }

    [Column("notes", TypeName = "text")]
    public string Notes { get; set; }

    [Column("position_id")]
    public int PositionId { get; set; }

    [Column("rnk")]
    public int Rnk { get; set; }

    [Column("pos_group")]
    public int PosGroup { get; set; }

    [ForeignKey("FactionId")]
    [InverseProperty("Ministers")]
    public virtual Faction Faction { get; set; }

    [ForeignKey("FkSanId")]
    [InverseProperty("Ministers")]
    public virtual Sanction FkSan { get; set; }

    [ForeignKey("GovernmentId")]
    [InverseProperty("Ministers")]
    public virtual Government Government { get; set; }

    [ForeignKey("KnessetId")]
    [InverseProperty("Ministers")]
    public virtual Knesset Knesset { get; set; }
}
