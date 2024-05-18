using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Politics.BL.Models;
using Politics.Converter;
using Politics.Dal.Abstractions;
using Politics.Dal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Politics.Dal;

public class PoliticsDal : IPoliticsDal
{
    private readonly PoliticsContext _context;
    private readonly ILogger<PoliticsDal> _logger;

    public PoliticsDal(PoliticsContext context, ILogger<PoliticsDal> logger)
    {
        _context = context;
        _logger = logger;
    }

    // Create Methods
    public async Task<IList<Faction>> InitFactions(IList<Models.Faction> factions, CancellationToken ct)
    {
        try
        {
            _context.Factions.AddRange(factions);
            await _context.SaveChangesAsync(ct);
            return factions.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to initialize factions: {ex.Message}");
            return null;
        }
    }

    public async Task InitGovernments(IList<Models.Government> governments, CancellationToken ct)
    {
        try
        {
            _context.Governments.AddRange(governments);
            await _context.SaveChangesAsync(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to initialize governments: {ex.Message}");
        }
    }

    public async Task<IList<Knesset>> InitKnessets(IList<Models.Knesset> knessets, CancellationToken ct)
    {
        try
        {
            _context.Knessets.AddRange(knessets);
            await _context.SaveChangesAsync(ct);
            return knessets.Select(k => k.ToBlModel()).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to initialize knessets: {ex.Message}");
            return null;
        }
    }

    public async Task InitMinisters(IList<Models.Minister> ministers, CancellationToken ct)
    {
        try
        {
            _context.Ministers.AddRange(ministers);
            await _context.SaveChangesAsync(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to initialize ministers: {ex.Message}");
        }
    }

    public async Task<IList<Mk>> InitMks(IList<Models.Mk> mks, CancellationToken ct)
    {
        try
        {
            _context.Mks.AddRange(mks);
            await _context.SaveChangesAsync(ct);
            return mks.Select(m => m.ToBlModel()).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to initialize MKs: {ex.Message}");
            return null;
        }
    }

    // Read Methods
    public async Task<IList<Faction>> GetFactions(CancellationToken ct = default)
    {
        try
        {
            var factions = await _context.Factions.ToListAsync(ct);
            return factions.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get factions: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Government>> GetGovernments(CancellationToken ct = default)
    {
        try
        {
            var governments = await _context.Governments.ToListAsync(ct);
            return governments.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get governments: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Knesset>> GetKnessets(CancellationToken ct = default)
    {
        try
        {
            var knessets = await _context.Knessets.ToListAsync(ct);
            return knessets.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get knessets: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Minister>> GetMinisters(CancellationToken ct = default)
    {
        try
        {
            var ministers = await _context.Ministers.ToListAsync(ct);
            return ministers.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get ministers: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Mk>> GetMks(CancellationToken ct = default)
    {
        try
        {
            var mks = await _context.Mks.ToListAsync(ct);
            return mks.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get MKs: {ex.Message}");
            return null;
        }
    }

    // Update Methods
    public async Task<Faction> UpdateFaction(Faction faction, CancellationToken ct = default)
    {
        try
        {
            var entity = await _context.Factions.FindAsync([faction.Id], ct);
            if (entity == null) return null;

            _context.Entry(entity).CurrentValues.SetValues(faction.ToDalModel());
            await _context.SaveChangesAsync(ct);
            return faction;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update faction: {ex.Message}");
            return null;
        }
    }

    public async Task<Government> UpdateGovernment(Government government, CancellationToken ct = default)
    {
        try
        {
            var entity = await _context.Governments.FindAsync([government.GovId], ct);
            if (entity == null) return null;

            _context.Entry(entity).CurrentValues.SetValues(government.ToDalModel());
            await _context.SaveChangesAsync(ct);
            return government;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update government: {ex.Message}");
            return null;
        }
    }

    public async Task<Knesset> UpdateKnesset(Knesset knesset, CancellationToken ct = default)
    {
        try
        {
            var entity = await _context.Knessets.FindAsync([knesset.Id], ct);
            if (entity == null) return null;

            _context.Entry(entity).CurrentValues.SetValues(knesset.ToDalModel());
            await _context.SaveChangesAsync(ct);
            return knesset;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update knesset: {ex.Message}");
            return null;
        }
    }

    public async Task<Minister> UpdateMinister(Minister minister, CancellationToken ct = default)
    {
        try
        {
            var entity = await _context.Ministers.FindAsync([minister.Id], ct);
            if (entity == null) return null;

            _context.Entry(entity).CurrentValues.SetValues(minister.ToDalModel());
            await _context.SaveChangesAsync(ct);
            return minister;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update minister: {ex.Message}");
            return null;
        }
    }

    public async Task<Mk> UpdateMk(Mk mk, CancellationToken ct = default)
    {
        try
        {
            var entity = await _context.Mks.FindAsync([mk.MkId], ct);
            if (entity == null) return null;

            _context.Entry(entity).CurrentValues.SetValues(mk.ToDalModel());
            await _context.SaveChangesAsync(ct);
            return mk;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update MK: {ex.Message}");
            return null;
        }
    }

    // Delete Methods
    public async Task<bool> DeleteFaction(int id, CancellationToken ct = default)
    {
        try
        {
            var entity = await _context.Factions.FindAsync([id], ct);
            if (entity == null) return false;

            _context.Factions.Remove(entity);
            await _context.SaveChangesAsync(ct);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete faction: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteGovernment(int id, CancellationToken ct = default)
    {
        try
        {
            var entity = await _context.Governments.FindAsync([id], ct);
            if (entity == null) return false;

            _context.Governments.Remove(entity);
            await _context.SaveChangesAsync(ct);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete government: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteKnesset(int id, CancellationToken ct = default)
    {
        try
        {
            var entity = await _context.Knessets.FindAsync([id], ct);
            if (entity == null) return false;

            _context.Knessets.Remove(entity);
            await _context.SaveChangesAsync(ct);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete knesset: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteMinister(int id, CancellationToken ct = default)
    {
        try
        {
            var entity = await _context.Ministers.FindAsync([id], ct);
            if (entity == null) return false;

            _context.Ministers.Remove(entity);
            await _context.SaveChangesAsync(ct);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete minister: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteMk(int id, CancellationToken ct = default)
    {
        try
        {
            var entity = await _context.Mks.FindAsync([id], ct);
            if (entity == null) return false;

            _context.Mks.Remove(entity);
            await _context.SaveChangesAsync(ct);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete MK: {ex.Message}");
            return false;
        }
    }
}
