using Microsoft.Extensions.Logging;
using Politics.BL.Abstractions;
using Politics.BL.Models;
using Politics.Dal.Abstractions;

namespace Politics.BL;

public class PoliticsRetriever : IPoliticsRetriever
{
    private readonly IPoliticsDal _politicsDal;
    private readonly ILogger<PoliticsRetriever> _logger;

    public PoliticsRetriever(IPoliticsDal politicsDal, ILogger<PoliticsRetriever> logger)
    {
        _politicsDal = politicsDal;
        _logger = logger;
    }

    public async Task<IList<Faction>> GetFactionsAsync(CancellationToken ct = default)
    {
        try
        {
            return await _politicsDal.GetFactions(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve factions: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Faction>> GetFactionsByIdsAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            var factions = await _politicsDal.GetFactions(ct);
            return factions.Where(f => ids.Contains(f.Id)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve factions by ids: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Government>> GetGovernmentsAsync(CancellationToken ct = default)
    {
        try
        {
            return await _politicsDal.GetGovernments(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve governments: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Government>> GetGovernmentsByIdsAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            var governments = await _politicsDal.GetGovernments(ct);
            return governments.Where(g => ids.Contains(g.GovId)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve governments by ids: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Knesset>> GetKnessetsAsync(CancellationToken ct = default)
    {
        try
        {
            return await _politicsDal.GetKnessets(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve knessets: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Knesset>> GetKnessetsByIdsAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            var knessets = await _politicsDal.GetKnessets(ct);
            return knessets.Where(k => ids.Contains(k.Id)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve knessets by ids: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Minister>> GetMinistersAsync(CancellationToken ct = default)
    {
        try
        {
            return await _politicsDal.GetMinisters(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve ministers: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Minister>> GetMinistersByIdsAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            var ministers = await _politicsDal.GetMinisters(ct);
            return ministers.Where(m => ids.Contains(m.Id)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve ministers by ids: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Mk>> GetMksAsync(CancellationToken ct = default)
    {
        try
        {
            return await _politicsDal.GetMks(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve MKs: {ex.Message}");
            return null;
        }
    }

    public async Task<IList<Mk>> GetMksByIdsAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            var mks = await _politicsDal.GetMks(ct);
            return mks.Where(m => ids.Contains(m.MkId)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve MKs by ids: {ex.Message}");
            return null;
        }
    }
}
