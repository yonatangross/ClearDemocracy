using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Politics.BL.Models;
using Politics.Converter;
using Politics.Dal.Abstractions;
using Politics.Dal.Context;
using Politics.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Politics.Dal;

public class PoliticsDal : IPoliticsDal
{
    private readonly ILogger<PoliticsDal> _logger;

    public PoliticsDal(ILogger<PoliticsDal> logger)
    {
        _logger = logger;
    }

    // Create Methods
    public async Task<IList<BL.Models.Faction>> InitFactions(IList<Models.Faction> factions, CancellationToken ct)
    {
        try
        {
            await using var context = new PoliticsContext();
            foreach (var faction in factions)
            {
                if (!context.Factions.Any(f => f.Id == faction.Id))
                {
                    context.Factions.Add(faction);
                }
                else
                {
                    context.Entry(faction).State = EntityState.Modified;
                }
            }
            await context.SaveChangesAsync(ct);
            return factions.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to initialize factions: {ex.Message}");
            throw;
        }
    }

    public async Task<IList<BL.Models.Government>> InitGovernments(IList<Models.Government> governments, CancellationToken ct)
    {
        try
        {
            await using var context = new PoliticsContext();
            foreach (var government in governments)
            {
                if (!context.Governments.Any(g => g.GovId == government.GovId))
                {
                    context.Governments.Add(government);
                }
                else
                {
                    context.Entry(government).State = EntityState.Modified;
                }
            }
            await context.SaveChangesAsync(ct);
            return governments.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to initialize governments: {ex.Message}");
            throw;
        }
    }

    public async Task<IList<BL.Models.Knesset>> InitKnessets(IList<Models.Knesset> knessets, CancellationToken ct)
    {
        try
        {
            await using var context = new PoliticsContext();
            foreach (var knesset in knessets)
            {
                if (!context.Knessets.Any(k => k.Id == knesset.Id))
                {
                    context.Knessets.Add(knesset);
                }
                else
                {
                    context.Entry(knesset).State = EntityState.Modified;
                }
            }
            await context.SaveChangesAsync(ct);
            return knessets.Select(k => k.ToBlModel()).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to initialize knessets: {ex.Message}");
            throw;
        }
    }

    public async Task<IList<BL.Models.Minister>> InitMinisters(IList<Models.Minister> ministers, CancellationToken ct)
    {
        try
        {
            await using var context = new PoliticsContext();
            foreach (var minister in ministers)
            {
                if (!context.Ministers.Any(m => m.Id == minister.Id))
                {
                    context.Ministers.Add(minister);
                }
                else
                {
                    context.Entry(minister).State = EntityState.Modified;
                }
            }
            await context.SaveChangesAsync(ct);
            return ministers.Select(k => k.ToBlModel()).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to initialize ministers: {ex.Message}");
            throw;
        }
    }

    public async Task<IList<BL.Models.Mk>> InitMks(IList<Models.Mk> mks, CancellationToken ct)
    {
        try
        {
            await using var context = new PoliticsContext();
            foreach (var mk in mks)
            {
                if (!context.Mks.Any(m => m.MkId == mk.MkId))
                {
                    context.Mks.Add(mk);
                }
                else
                {
                    context.Entry(mk).State = EntityState.Modified;
                }
            }
            await context.SaveChangesAsync(ct);
            return mks.Select(m => m.ToBlModel()).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to initialize MKs: {ex.Message}");
            throw;
        }
    }

    // Read Methods
    public async Task<IList<BL.Models.Faction>> GetFactions(CancellationToken ct = default)
    {
        await using var context = new PoliticsContext();
        try
        {
            var factions = await context.Factions.ToListAsync(ct);
            return factions.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get factions: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<BL.Models.Government>> GetGovernments(CancellationToken ct = default)
    {
        await using var context = new PoliticsContext();
        try
        {
            var governments = await context.Governments.ToListAsync(ct);
            return governments.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get governments: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<BL.Models.Knesset>> GetKnessets(CancellationToken ct = default)
    {
        await using var context = new PoliticsContext();
        try
        {
            var knessets = await context.Knessets.ToListAsync(ct);
            return knessets.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get knessets: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<BL.Models.Minister>> GetMinisters(CancellationToken ct = default)
    {
        await using var context = new PoliticsContext();
        try
        {
            var ministers = await context.Ministers.ToListAsync(ct);
            return ministers.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get ministers: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<BL.Models.Mk>> GetMks(CancellationToken ct = default)
    {
        await using var context = new PoliticsContext();
        try
        {
            var mks = await context.Mks.ToListAsync(ct);
            return mks.Select(ModelConverter.ToBlModel).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get MKs: {ex.Message}");
            return null;
        }
    }

    // Update Methods
    public async Task<BL.Models.Faction> UpdateFaction(Models.Faction faction, CancellationToken ct = default)
    {
        await using var context = new PoliticsContext();
        try
        {
            var entity = await context.Factions.FindAsync([faction.Id], ct);
            if (entity == null) return null;

            context.Entry(entity).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync(ct);
            return faction.ToBlModel();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update faction: {ex.Message}");
            return null;
        }
    }

    public async Task<BL.Models.Government> UpdateGovernment(Models.Government government, CancellationToken ct = default)
    {
        await using var context = new PoliticsContext();
        try
        {
            var entity = await context.Governments.FindAsync([government.GovId], ct);
            if (entity == null) return null;

            context.Entry(entity).CurrentValues.SetValues(government);
            await context.SaveChangesAsync(ct);
            return government.ToBlModel();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update government: {ex.Message}");
            throw;
        }
    }

    public async Task<BL.Models.Knesset> UpdateKnesset(Models.Knesset knesset, CancellationToken ct = default)
    {
        await using var context = new PoliticsContext();
        try
        {
            var entity = await context.Knessets.FindAsync([knesset.Id], ct);
            if (entity == null) return null;

            context.Entry(entity).CurrentValues.SetValues(knesset);
            await context.SaveChangesAsync(ct);
            return knesset.ToBlModel();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update knesset: {ex.Message}");
            return null;
        }
    }

    public async Task<BL.Models.Minister> UpdateMinister(Models.Minister minister, CancellationToken ct = default)
    {
        await using var context = new PoliticsContext();
        try
        {
            var entity = await context.Ministers.FindAsync([minister.Id], ct);
            if (entity == null) return null;

            context.Entry(entity).CurrentValues.SetValues(minister);
            await context.SaveChangesAsync(ct);
            return minister.ToBlModel();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update minister: {ex.Message}");
            return null;
        }
    }

    public async Task<BL.Models.Mk> UpdateMk(Models.Mk mk, CancellationToken ct = default)
    {
        await using var context = new PoliticsContext();
        try
        {
            var entity = await context.Mks.FindAsync([mk.MkId], ct);
            if (entity == null) return null;

            context.Entry(entity).CurrentValues.SetValues(mk);
            await context.SaveChangesAsync(ct);
            return mk.ToBlModel();
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
        await using var context = new PoliticsContext();
        try
        {
            var entity = await context.Factions.FindAsync([id], ct);
            if (entity == null) return false;

            context.Factions.Remove(entity);
            await context.SaveChangesAsync(ct);
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
        await using var context = new PoliticsContext();
        try
        {
            var entity = await context.Governments.FindAsync([id], ct);
            if (entity == null) return false;

            context.Governments.Remove(entity);
            await context.SaveChangesAsync(ct);
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
        await using var context = new PoliticsContext();
        try
        {
            var entity = await context.Knessets.FindAsync([id], ct);
            if (entity == null) return false;

            context.Knessets.Remove(entity);
            await context.SaveChangesAsync(ct);
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
        await using var context = new PoliticsContext();
        try
        {
            var entity = await context.Ministers.FindAsync([id], ct);
            if (entity == null) return false;

            context.Ministers.Remove(entity);
            await context.SaveChangesAsync(ct);
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
        await using var context = new PoliticsContext();
        try
        {
            var entity = await context.Mks.FindAsync([id], ct);
            if (entity == null) return false;

            context.Mks.Remove(entity);
            await context.SaveChangesAsync(ct);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete MK: {ex.Message}");
            return false;
        }
    }
}
