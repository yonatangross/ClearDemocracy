using System.ComponentModel.DataAnnotations;

namespace Politics.BL.Models;

public class Minister
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public int GoPositionId { get; set; }

    public int SanPositionId { get; set; }

    [Required]
    [StringLength(255)]
    public string PositionName { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [StringLength(255)]
    public string MkName { get; set; }

    public int FkSanId { get; set; }

    public int PosId { get; set; }

    public int? FactionId { get; set; }

    public int KnessetId { get; set; }

    public int GovernmentId { get; set; }

    public int Ordinal { get; set; }

    public int MinistryId { get; set; }

    public DateTime GovStartDate { get; set; }

    public DateTime? GovFinishDate { get; set; }

    public DateTime PositionStartDate { get; set; }

    public DateTime? PositionFinishedDate { get; set; }

    public bool IsMk { get; set; }

    [Required]
    [StringLength(15)]
    public string Gender { get; set; }

    public string Notes { get; set; }

    public int PositionId { get; set; }

    public int Rnk { get; set; }

    public int PosGroup { get; set; }

    // Navigation properties
    public Faction Faction { get; set; }
    public Knesset Knesset { get; set; }
    public Government Government { get; set; }
}
