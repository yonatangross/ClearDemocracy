using ClearDemocracy.Knesset.Dal.Context;
using ClearDemocracy.KnessetService.Models;
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
            var existingMk = await _context.Mks.FindAsync(mk.MkId);
            if (existingMk != null)
            {
                // Update the existing entity
                _context.Entry(existingMk).CurrentValues.SetValues(mk);
            }
            else
            {
                // Add the new entity
                await _context.Mks.AddAsync(mk);
            }
        }
        await _context.SaveChangesAsync(ct);

        return mks;
    }
}
