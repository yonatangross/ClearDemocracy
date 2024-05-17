using System;
using System.Collections.Generic;

namespace ClearDemocracy.Knesset.Dal.Models;

public partial class government
{
    public int GovId { get; set; }

    public string GovName { get; set; }

    public DateTime GovStartDate { get; set; }

    public string GovNamedStartDateStr { get; set; }

    public string GovStartDateStr { get; set; }

    public DateTime? GovFinishDate { get; set; }

    public string GovNamedFinishDateStr { get; set; }

    public string GovFinishDateStr { get; set; }

    public string GovPmimage { get; set; }

    public string GovBannerImage { get; set; }

    public ulong GovCurrent { get; set; }

    public ulong SearchedGov { get; set; }

    public string KnessetNames { get; set; }

    public string GovNotes { get; set; }
}
