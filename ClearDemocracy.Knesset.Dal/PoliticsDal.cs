using ClearDemocracy.Knesset.Dal.Context;
using ClearDemocracy.KnessetService.Models;
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

        var dbMks = mks.Select(mk => new Models.Mk
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
            var existingMk = await _context.Mks.FindAsync(new object[] { mk.MkId }, ct);
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

    public async Task<IList<Faction>> GetFactions(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Faction>> GetFactionsByIds(IList<int> ids, CancellationToken ct = default)
    {
        throw new NotImplementedException();
        //return await _context.Factions.Where(faction => ids.Contains(faction.FactionId)).ToListAsync(ct);
    }

    public async Task AddMks(IList<MK> mks, CancellationToken ct = default)
    {
        var dbMks = mks.Select(mk => new Models.Mk
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
    }

    public async Task UpdateMks(IList<MK> mks, CancellationToken ct = default)
    {
        foreach (var mk in mks)
        {
            var dbMk = new Models.Mk
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

            var existingMk = await _context.Mks.FindAsync(new object[] { dbMk.MkId }, ct);
            if (existingMk != null)
            {
                // Update the existing entity
                _context.Entry(existingMk).CurrentValues.SetValues(dbMk);
            }
        }
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteMks(IList<int> ids, CancellationToken ct = default)
    {
        var mks = await _context.Mks.Where(mk => ids.Contains(mk.MkId)).ToListAsync(ct);
        if (mks != null && mks.Count > 0)
        {
            _context.Mks.RemoveRange(mks);
            await _context.SaveChangesAsync(ct);
        }
    }

    public async Task<IList<Faction>> InitFactions(IList<Faction> factions, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<KnessetService.Models.Knesset>> InitKnessets(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<KnessetService.Models.Knesset>> GetKnessets(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<KnessetService.Models.Knesset>> GetKnessetsByIds(IList<int> ids, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task AddFactions(IList<Faction> factions, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateFactions(IList<Faction> factions, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteFactions(IList<int> ids, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task AddKnessets(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateKnessets(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteKnessets(IList<int> ids, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
