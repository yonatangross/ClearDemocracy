namespace KnessetService.BL;

public static class ModelConverter
{
    // Convert DAL Mk to BL Mk
    public static BL.Models.Mk ToBlModel(this Dal.Models.Mk dalMk)
    {
        if (dalMk == null) return null;

        return new BL.Models.Mk
        {
            MkId = dalMk.MkId,
            FirstName = dalMk.FirstName,
            LastName = dalMk.LastName,
            FactionId = dalMk.FactionId,
            ImagePath = dalMk.ImagePath,
            FirstLetter = dalMk.FirstLetter,
            Email = dalMk.Email,
            Phone = dalMk.Phone,
            Gender = dalMk.Gender,
            YearDate = dalMk.YearDate,
            Fax = dalMk.Fax,
            Facebook = dalMk.Facebook,
            Twitter = dalMk.Twitter,
            Instagram = dalMk.Instagram,
            Youtube = dalMk.Youtube,
            IsPresent = dalMk.IsPresent,
            IsCoalition = dalMk.IsCoalition,
            WebsiteUrl = dalMk.WebsiteUrl
        };
    }

    // Convert DAL Minister to BL Minister
    public static BL.Models.Minister ToBlModel(this Dal.Models.Minister dalMinister)
    {
        if (dalMinister == null) return null;

        return new BL.Models.Minister
        {
            Id = dalMinister.Id,
            TypeId = dalMinister.TypeId,
            GoPositionId = dalMinister.GoPositionId,
            SanPositionId = dalMinister.SanPositionId,
            PositionName = dalMinister.PositionName,
            Name = dalMinister.Name,
            MkName = dalMinister.MkName,
            FkSanId = dalMinister.FkSanId,
            PosId = dalMinister.PosId,
            FactionId = dalMinister.FactionId,
            KnessetId = dalMinister.KnessetId,
            GovernmentId = dalMinister.GovernmentId,
            Ordinal = dalMinister.Ordinal,
            MinistryId = dalMinister.MinistryId,
            GovStartDate = dalMinister.GovStartDate,
            GovFinishDate = dalMinister.GovFinishDate,
            PositionStartDate = dalMinister.PositionStartDate,
            PositionFinishedDate = dalMinister.PositionFinishedDate,
            IsMk = dalMinister.IsMk != 0,
            Gender = dalMinister.Gender,
            Notes = dalMinister.Notes,
            PositionId = dalMinister.PositionId,
            Rnk = dalMinister.Rnk,
            PosGroup = dalMinister.PosGroup
        };
    }

    // Convert DAL Knesset to BL Knesset
    public static BL.Models.Knesset ToBlModel(this Dal.Models.Knesset dalKnesset)
    {
        if (dalKnesset == null) return null;

        return new BL.Models.Knesset
        {
            Id = dalKnesset.Id,
            Name = dalKnesset.Name,
            FromDate = dalKnesset.FromDate,
            ToDate = dalKnesset.ToDate,
            IsCurrent = dalKnesset.IsCurrent
        };
    }

    // Convert DAL Government to BL Government
    public static BL.Models.Government ToBlModel(this Dal.Models.Government dalGovernment)
    {
        if (dalGovernment == null) return null;

        return new BL.Models.Government
        {
            GovId = dalGovernment.GovId,
            GovName = dalGovernment.GovName,
            GovStartDate = dalGovernment.GovStartDate,
            GovFinishDate = dalGovernment.GovFinishDate,
            GovPmImage = dalGovernment.GovPmImage,
            GovBannerImage = dalGovernment.GovBannerImage,
            GovCurrent = dalGovernment.GovCurrent != 0,
            SearchedGov = dalGovernment.SearchedGov != 0,
            KnessetNames = dalGovernment.KnessetNames,
            GovNotes = dalGovernment.GovNotes
        };
    }

    // Convert DAL Faction to BL Faction
    public static BL.Models.Faction ToBlModel(this Dal.Models.Faction dalFaction)
    {
        if (dalFaction == null) return null;

        return new BL.Models.Faction
        {
            Id = dalFaction.Id,
            Name = dalFaction.Name,
            KnessetId = dalFaction.KnessetId,
            IsPartial = dalFaction.IsPartial
        };
    }

    // Convert BL Mk to DAL Mk
    public static Dal.Models.Mk ToDalModel(this BL.Models.Mk blMk)
    {
        if (blMk == null) return null;

        return new Dal.Models.Mk
        {
            MkId = blMk.MkId,
            FirstName = blMk.FirstName,
            LastName = blMk.LastName,
            FactionId = blMk.FactionId,
            ImagePath = blMk.ImagePath,
            FirstLetter = blMk.FirstLetter,
            Email = blMk.Email,
            Phone = blMk.Phone,
            Gender = blMk.Gender,
            YearDate = blMk.YearDate,
            Fax = blMk.Fax,
            Facebook = blMk.Facebook,
            Twitter = blMk.Twitter,
            Instagram = blMk.Instagram,
            Youtube = blMk.Youtube,
            IsPresent = blMk.IsPresent,
            IsCoalition = blMk.IsCoalition,
            WebsiteUrl = blMk.WebsiteUrl
        };
    }

    // Convert BL Minister to DAL Minister
    public static Dal.Models.Minister ToDalModel(this BL.Models.Minister blMinister)
    {
        if (blMinister == null) return null;

        return new Dal.Models.Minister
        {
            Id = blMinister.Id,
            TypeId = blMinister.TypeId,
            GoPositionId = blMinister.GoPositionId,
            SanPositionId = blMinister.SanPositionId,
            PositionName = blMinister.PositionName,
            Name = blMinister.Name,
            MkName = blMinister.MkName,
            FkSanId = blMinister.FkSanId,
            PosId = blMinister.PosId,
            FactionId = blMinister.FactionId,
            KnessetId = blMinister.KnessetId,
            GovernmentId = blMinister.GovernmentId,
            Ordinal = blMinister.Ordinal,
            MinistryId = blMinister.MinistryId,
            GovStartDate = blMinister.GovStartDate,
            GovFinishDate = blMinister.GovFinishDate,
            PositionStartDate = blMinister.PositionStartDate,
            PositionFinishedDate = blMinister.PositionFinishedDate,
            IsMk = (ulong)(blMinister.IsMk ? 1 : 0),
            Gender = blMinister.Gender,
            Notes = blMinister.Notes,
            PositionId = blMinister.PositionId,
            Rnk = blMinister.Rnk,
            PosGroup = blMinister.PosGroup
        };
    }

    // Convert BL Knesset to DAL Knesset
    public static Dal.Models.Knesset ToDalModel(this BL.Models.Knesset blKnesset)
    {
        if (blKnesset == null) return null;

        return new Dal.Models.Knesset
        {
            Id = blKnesset.Id,
            Name = blKnesset.Name,
            FromDate = blKnesset.FromDate,
            ToDate = blKnesset.ToDate,
            IsCurrent = blKnesset.IsCurrent
        };
    }

    // Convert BL Government to DAL Government
    public static Dal.Models.Government ToDalModel(this BL.Models.Government blGovernment)
    {
        if (blGovernment == null) return null;

        return new Dal.Models.Government
        {
            GovId = blGovernment.GovId,
            GovName = blGovernment.GovName,
            GovStartDate = blGovernment.GovStartDate,
            GovFinishDate = blGovernment.GovFinishDate,
            GovPmImage = blGovernment.GovPmImage,
            GovBannerImage = blGovernment.GovBannerImage,
            GovCurrent = (ulong)(blGovernment.GovCurrent ? 1 : 0),
            SearchedGov = (ulong)(blGovernment.SearchedGov ? 1 : 0),
            KnessetNames = blGovernment.KnessetNames,
            GovNotes = blGovernment.GovNotes
        };
    }

    // Convert BL Faction to DAL Faction
    public static Dal.Models.Faction ToDalModel(this BL.Models.Faction blFaction)
    {
        if (blFaction == null) return null;

        return new Dal.Models.Faction
        {
            Id = blFaction.Id,
            Name = blFaction.Name,
            KnessetId = blFaction.KnessetId,
            IsPartial = blFaction.IsPartial
        };
    }
}
}