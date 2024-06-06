using System.ComponentModel.DataAnnotations;

namespace Politics.BL.Models;

public class Faction
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    public int KnessetId { get; set; }

    public bool IsPartial { get; set; }

    // Navigation properties
    public Knesset Knesset { get; set; }
    public ICollection<Mk> Mks { get; set; }
}
