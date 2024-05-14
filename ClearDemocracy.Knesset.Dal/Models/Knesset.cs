using System;
using System.Collections.Generic;

namespace ClearDemocracy.Knesset.Dal.Models;

public partial class Knesset
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string FromDateHeb { get; set; }

    public string ToDateHeb { get; set; }

    public bool IsCurrent { get; set; }

    public virtual ICollection<Faction> Factions { get; set; } = new List<Faction>();
}
