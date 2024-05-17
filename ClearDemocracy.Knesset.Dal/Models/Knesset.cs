using System;
using System.Collections.Generic;

namespace ClearDemocracy.Knesset.Dal.Models;

public partial class knesset
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string FromDateHeb { get; set; }

    public string ToDateHeb { get; set; }

    public bool IsCurrent { get; set; }

    public virtual ICollection<faction> Factions { get; set; } = new List<faction>();
}
