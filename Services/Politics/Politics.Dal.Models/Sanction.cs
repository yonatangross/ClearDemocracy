using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Politics.Dal.Models;

[Table("sanction")]
public partial class Sanction
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; }

    [InverseProperty("FkSan")]
    public virtual ICollection<Minister> Ministers { get; set; } = new List<Minister>();
}
