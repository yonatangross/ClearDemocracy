using System;
using System.Collections.Generic;

namespace ClearDemocracy.Knesset.Dal.Models;

public partial class minister
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public int GoPositionId { get; set; }

    public int SanPositionId { get; set; }

    public string PositionName { get; set; }

    public string Name { get; set; }

    public string MkName { get; set; }

    public int FkSanId { get; set; }

    public int PosId { get; set; }

    public int? FactionId { get; set; }

    public string FactionName { get; set; }

    public int Knesset { get; set; }

    public string KnessetName { get; set; }

    public int GovermentId { get; set; }

    public string GovermentName { get; set; }

    public int Ordinal { get; set; }

    public int Ordinal2 { get; set; }

    public int OrdinalFirst { get; set; }

    public int MinistryId { get; set; }

    public string MinistryName { get; set; }

    public DateTime GovStartDate { get; set; }

    public DateTime? GovFinishDate { get; set; }

    public string GovStartDateStr { get; set; }

    public string GovStartDateStr2 { get; set; }

    public string GovFinishDateStr { get; set; }

    public string GovFinishDateStr2 { get; set; }

    public DateTime PositionStratDate { get; set; }

    public DateTime? PositionFinishedDate { get; set; }

    public ulong IsMk { get; set; }

    public int LuGender { get; set; }

    public string Notes { get; set; }

    public int PositionId { get; set; }

    public int Rnk { get; set; }

    public int PosGroup { get; set; }

    public string StartDateStr { get; set; }

    public string FinishDateStr { get; set; }

    public string GovGroups { get; set; }
}
