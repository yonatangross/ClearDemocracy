using System;
using System.Collections.Generic;

namespace ClearDemocracy.Knesset.Dal.Models;

public partial class faction
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int KnessetId { get; set; }

    public bool IsPartial { get; set; }

    public virtual knesset Knesset { get; set; }
}
