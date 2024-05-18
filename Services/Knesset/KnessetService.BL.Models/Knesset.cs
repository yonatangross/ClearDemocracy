using System.ComponentModel.DataAnnotations;

namespace KnessetService.BL.Models;

public class Knesset
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public bool IsCurrent { get; set; }
}
