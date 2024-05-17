using ClearDemocracy.Knesset.Dal.Context;
using ClearDemocracy.Knesset.Dal.Models;
using ClearDemocracy.KnessetService.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClearDemocracy.Knesset.Dal;

public class PoliticsDal : IPoliticsDal
{
    private readonly KnessetContext _context;

    public PoliticsDal(KnessetContext context)
    {
        _context = context;
    }

    public async Task<IList<MK>> InitMks(IList<MK> mks, CancellationToken ct = default)
    {
        if (mks == null || !mks.Any())
        {
            throw new ArgumentException("The MKs list cannot be null or empty.");
        }

        var dbMks = mks.Select(mk => new Models.mk
        {
            MkId = mk.MkId,
            Email = mk.Email,
            Facebook = mk.Facebook,
            FactionName = mk.FactionName,
            Fax = mk.Fax,
            FirstLetter = mk.FirstLetter,
            Firstname = mk.Firstname,
            ImagePath = mk.ImagePath,
            Instagram = mk.Instagram,
            Lastname = mk.Lastname,
            Phone = mk.Phone,
            Twitter = mk.Twitter,
            WebsiteUrl = mk.WebsiteUrl,
            Youtube = mk.Youtube
        });

        foreach (var mk in dbMks)
        {
            var existingMk = await _context.Mks.FindAsync([mk.MkId], ct);
            if (existingMk != null)
            {
                // Update the existing entity
                _context.Entry(existingMk).CurrentValues.SetValues(mk);
            }
            else
            {
                // Add the new entity
                await _context.Mks.AddAsync(mk, ct);
            }
        }
        await _context.SaveChangesAsync(ct);

        return mks;
    }

    public async Task<IList<MK>> GetMks(IList<int> ids, CancellationToken ct = default)
    {
        return await _context.Mks
            .Where(mk => ids.Contains(mk.MkId))
            .Select(mk => new MK
            {
                MkId = mk.MkId,
                Email = mk.Email,
                Facebook = mk.Facebook,
                FactionName = mk.FactionName,
                Fax = mk.Fax,
                FirstLetter = mk.FirstLetter,
                Firstname = mk.Firstname,
                ImagePath = mk.ImagePath,
                Instagram = mk.Instagram,
                Lastname = mk.Lastname,
                Phone = mk.Phone,
                Twitter = mk.Twitter,
                WebsiteUrl = mk.WebsiteUrl,
                Youtube = mk.Youtube
            })
            .ToListAsync(ct);
    }

    public async Task<IList<MK>> GetAllMks(CancellationToken ct = default)
    {
        return await _context.Mks
            .Select(mk => new MK
            {
                MkId = mk.MkId,
                Email = mk.Email,
                Facebook = mk.Facebook,
                FactionName = mk.FactionName,
                Fax = mk.Fax,
                FirstLetter = mk.FirstLetter,
                Firstname = mk.Firstname,
                ImagePath = mk.ImagePath,
                Instagram = mk.Instagram,
                Lastname = mk.Lastname,
                Phone = mk.Phone,
                Twitter = mk.Twitter,
                WebsiteUrl = mk.WebsiteUrl,
                Youtube = mk.Youtube
            })
            .ToListAsync(ct);
    }

    public async Task<IList<Faction>> GetAllFactions(CancellationToken ct = default)
    {
        return await _context.Factions
            .Select(faction => new KnessetService.Models.Faction
            {
                ID = faction.Id,
                KnessetID = faction.KnessetId.ToString(),
                IsPartial = faction.IsPartial,
                Name = faction.Name
            })
            .ToListAsync(ct);
    }

    public async Task<IList<Faction>> GetFactions(IList<int> ids, CancellationToken ct = default)
    {
        return await _context.Factions
            .Where(faction => ids.Contains(faction.Id))
            .Select(faction => new KnessetService.Models.Faction
            {
                ID = faction.Id,
                KnessetID = faction.KnessetId.ToString(),
                IsPartial = faction.IsPartial,
                Name = faction.Name
            })
            .ToListAsync(ct);
    }

    public async Task<IList<MK>> AddMks(IList<MK> mks, CancellationToken ct = default)
    {
        var dbMks = mks.Select(mk => new mk
        {
            MkId = mk.MkId,
            Email = mk.Email,
            Facebook = mk.Facebook,
            FactionName = mk.FactionName,
            Fax = mk.Fax,
            FirstLetter = mk.FirstLetter,
            Firstname = mk.Firstname,
            ImagePath = mk.ImagePath,
            Instagram = mk.Instagram,
            Lastname = mk.Lastname,
            Phone = mk.Phone,
            Twitter = mk.Twitter,
            WebsiteUrl = mk.WebsiteUrl,
            Youtube = mk.Youtube
        });

        await _context.Mks.AddRangeAsync(dbMks, ct);
        await _context.SaveChangesAsync(ct);

        return mks;
    }

    public async Task<IList<MK>> UpdateMks(IList<MK> mks, CancellationToken ct = default)
    {
        foreach (var mk in mks)
        {
            var dbMk = new Models.mk
            {
                MkId = mk.MkId,
                Email = mk.Email,
                Facebook = mk.Facebook,
                FactionName = mk.FactionName,
                Fax = mk.Fax,
                FirstLetter = mk.FirstLetter,
                Firstname = mk.Firstname,
                ImagePath = mk.ImagePath,
                Instagram = mk.Instagram,
                Lastname = mk.Lastname,
                Phone = mk.Phone,
                Twitter = mk.Twitter,
                WebsiteUrl = mk.WebsiteUrl,
                Youtube = mk.Youtube
            };

            var existingMk = await _context.Mks.FindAsync([dbMk.MkId], ct);
            if (existingMk != null)
            {
                // Update the existing entity
                _context.Entry(existingMk).CurrentValues.SetValues(dbMk);
            }
        }
        await _context.SaveChangesAsync(ct);

        return mks;
    }

    public async Task<IList<int>> DeleteMks(IList<int> ids, CancellationToken ct = default)
    {
        var mks = await _context.Mks.Where(mk => ids.Contains(mk.MkId)).ToListAsync(ct);
        if (mks != null && mks.Count > 0)
        {
            _context.Mks.RemoveRange(mks);
            await _context.SaveChangesAsync(ct);
        }

        return ids;
    }

    public async Task<IList<Models.faction>> InitFactions(IList<Models.faction> factions, CancellationToken ct = default)
    {
        if (factions == null || !factions.Any())
        {
            throw new ArgumentException("The factions list cannot be null or empty.");
        }

        var dbFactions = factions.Select(faction => new Models.faction
        {
            Id = faction.Id,
            KnessetId = faction.KnessetId,
            IsPartial = faction.IsPartial,
            Name = faction.Name
        });

        foreach (var faction in dbFactions)
        {
            var existingFaction = await _context.Factions.FindAsync([faction.Id], ct);
            if (existingFaction != null)
            {
                // Update the existing entity
                _context.Entry(existingFaction).CurrentValues.SetValues(faction);
            }
            else
            {
                // Add the new entity
                await _context.Factions.AddAsync(faction, ct);
            }
        }

        await _context.SaveChangesAsync(ct);
        return factions;
    }

    public async Task<IList<KnessetService.Api.Models.Knesset>> InitKnessets(IList<KnessetService.Api.Models.Knesset> knessets, CancellationToken ct = default)
    {
        if (knessets == null || !knessets.Any())
        {
            throw new ArgumentException("The knessets list cannot be null or empty.");
        }

        var dbKnessets = knessets.Select(knesset => new Models.knesset
        {
            Id = knesset.ID,
            Name = knesset.Name,
            FromDate = knesset.FromDate,
            ToDate = knesset.ToDate,
            FromDateHeb = knesset.FromDateHeb,
            ToDateHeb = knesset.ToDateHeb,
            IsCurrent = knesset.IsCurrent

        });

        foreach (var knesset in dbKnessets)
        {
            var existingKnesset = await _context.Knessets.FindAsync([knesset.Id], ct);
            if (existingKnesset != null)
            {
                // Update the existing entity
                _context.Entry(existingKnesset).CurrentValues.SetValues(knesset);
            }
            else
            {
                // Add the new entity
                await _context.Knessets.AddAsync(knesset, ct);
            }
        }

        await _context.SaveChangesAsync(ct);
        return knessets;

    }

    public async Task<IList<KnessetService.Api.Models.Knesset>> GetAllKnessets(CancellationToken ct = default)
    {
        return await _context.Knessets
            .Select(knesset => new KnessetService.Models.Knesset
            {
                ID = knesset.Id,
                Name = knesset.Name,
                FromDate = knesset.FromDate,
                ToDate = knesset.ToDate,
                FromDateHeb = knesset.FromDateHeb,
                ToDateHeb = knesset.ToDateHeb,
                IsCurrent = knesset.IsCurrent
            })
            .ToListAsync(ct);
    }

    public async Task<IList<KnessetService.Api.Models.Knesset>> GetKnessets(IList<int> ids, CancellationToken ct = default)
    {
        return await _context.Knessets
            .Where(knesset => ids.Contains(knesset.Id))
            .Select(knesset => new KnessetService.Models.Knesset
            {
                ID = knesset.Id,
                Name = knesset.Name,
                FromDate = knesset.FromDate,
                ToDate = knesset.ToDate,
                FromDateHeb = knesset.FromDateHeb,
                ToDateHeb = knesset.ToDateHeb,
                IsCurrent = knesset.IsCurrent
            })
            .ToListAsync(ct);
    }

    public async Task<IList<Models.faction>> AddFactions(IList<Models.faction> factions, CancellationToken ct = default)
    {
        var dbFactions = factions.Select(faction => new Models.faction
        {
            Id = faction.Id,
            KnessetId = faction.KnessetId,
            IsPartial = faction.IsPartial,
            Name = faction.Name
        });

        await _context.Factions.AddRangeAsync(dbFactions, ct);
        await _context.SaveChangesAsync(ct);

        return factions;
    }

    public async Task<IList<Models.faction>> UpdateFactions(IList<Models.faction> factions, CancellationToken ct = default)
    {
        foreach (var faction in factions)
        {
            var dbFaction = new Models.faction
            {
                Id = faction.Id,
                KnessetId = faction.KnessetId,
                IsPartial = faction.IsPartial,
                Name = faction.Name
            };

            var existingFaction = await _context.Factions.FindAsync([dbFaction.Id], ct);
            if (existingFaction != null)
            {
                // Update the existing entity
                _context.Entry(existingFaction).CurrentValues.SetValues(dbFaction);
            }
        }
        await _context.SaveChangesAsync(ct);

        return factions;
    }

    public async Task<IList<int>> DeleteFactions(IList<int> ids, CancellationToken ct = default)
    {
        var factions = await _context.Factions.Where(faction => ids.Contains(faction.Id)).ToListAsync(ct);
        if (factions != null && factions.Count > 0)
        {
            _context.Factions.RemoveRange(factions);
            await _context.SaveChangesAsync(ct);
        }

        return ids;
    }

    public async Task<IList<KnessetService.Api.Models.Knesset>> AddKnessets(IList<KnessetService.Api.Models.Knesset> knessets, CancellationToken ct = default)
    {
        var dbKnessets = knessets.Select(knesset => new Models.knesset
        {
            Id = knesset.ID,
            Name = knesset.Name,
            FromDate = knesset.FromDate,
            ToDate = knesset.ToDate,
            FromDateHeb = knesset.FromDateHeb,
            ToDateHeb = knesset.ToDateHeb,
            IsCurrent = knesset.IsCurrent
        });

        await _context.Knessets.AddRangeAsync(dbKnessets, ct);
        await _context.SaveChangesAsync(ct);

        return knessets;

    }

    public async Task<IList<KnessetService.Api.Models.Knesset>> UpdateKnessets(IList<KnessetService.Api.Models.Knesset> knessets, CancellationToken ct = default)
    {
        foreach (var knesset in knessets)
        {
            var dbKnesset = new Models.knesset
            {
                Id = knesset.ID,
                Name = knesset.Name,
                FromDate = knesset.FromDate,
                ToDate = knesset.ToDate,
                FromDateHeb = knesset.FromDateHeb,
                ToDateHeb = knesset.ToDateHeb,
                IsCurrent = knesset.IsCurrent
            };

            var existingKnesset = await _context.Knessets.FindAsync([dbKnesset.Id], ct);
            if (existingKnesset != null)
            {
                // Update the existing entity
                _context.Entry(existingKnesset).CurrentValues.SetValues(dbKnesset);
            }
        }
        await _context.SaveChangesAsync(ct);

        return knessets;
    }

    public async Task<IList<int>> DeleteKnessets(IList<int> ids, CancellationToken ct = default)
    {
        var knessets = await _context.Knessets.Where(knesset => ids.Contains(knesset.Id)).ToListAsync(ct);
        if (knessets != null && knessets.Count > 0)
        {
            _context.Knessets.RemoveRange(knessets);
            await _context.SaveChangesAsync(ct);
        }

        return ids;
    }

    public async Task<IList<Faction>> InitFactions(IList<Faction> factions, CancellationToken ct = default)
    {
        var dbFactions = factions.Select(faction => new Models.faction
        {
            Id = faction.ID,
            KnessetId = int.Parse(faction.KnessetID),
            IsPartial = faction.IsPartial,
            Name = faction.Name
        });

        foreach (var faction in dbFactions)
        {
            var existingFaction = await _context.Factions.FindAsync([faction.Id], ct);
            if (existingFaction != null)
            {
                // Update the existing entity
                _context.Entry(existingFaction).CurrentValues.SetValues(faction);
            }
            else
            {
                // Add the new entity
                await _context.Factions.AddAsync(faction, ct);
            }
        }

        await _context.SaveChangesAsync(ct);
        return factions;
    }

    public async Task<IList<Faction>> AddFactions(IList<Faction> factions, CancellationToken ct = default)
    {
        var dbFactions = factions.Select(faction => new Models.faction
        {
            Id = faction.ID,
            KnessetId = int.Parse(faction.KnessetID),
            IsPartial = faction.IsPartial,
            Name = faction.Name
        });

        await _context.Factions.AddRangeAsync(dbFactions, ct);
        await _context.SaveChangesAsync(ct);

        return factions;
    }

    public async Task<IList<Faction>> UpdateFactions(IList<Faction> factions, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    Task<IList<Faction>> IPoliticsDal.GetAllFactions(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    Task<IList<Faction>> IPoliticsDal.GetFactions(IList<int> ids, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
