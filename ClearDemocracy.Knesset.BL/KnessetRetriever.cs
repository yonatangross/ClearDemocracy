using ClearDemocracy.Knesset.BL.Abstractions;
using ClearDemocracy.Knesset.Dal;
using ClearDemocracy.KnessetService.Models;
using Microsoft.Extensions.Logging;

namespace ClearDemocracy.Knesset.BL;

public class KnessetRetriever : IKnessetRetriever
{
    private readonly IPoliticsDal _politicsDal;
    private readonly ILogger<KnessetRetriever> _logger;

    public KnessetRetriever(ILogger<KnessetRetriever> logger, IPoliticsDal politicsDal)
    {
        _logger = logger;
        _politicsDal = politicsDal;
    }

    public async Task<IList<MK>> GetMksAsync(CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Retrieving all MKs from DAL...");
            var mks = await _politicsDal.GetAllMks(ct);
            return mks;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting all MKs.");
            throw;
        }
    }

    public async Task<IList<MK>> GetMksByIdsAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Retrieving MKs by IDs from DAL...");
            var mks = await _politicsDal.GetMks(ids, ct);
            return mks;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting MKs by IDs.");
            throw;
        }
    }

    public async Task<IList<Faction>> GetFactionsAsync(CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Retrieving factions from DAL...");
            var factions = await _politicsDal.GetFactions(ct);
            return factions;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting factions.");
            throw;
        }
    }

    public async Task<IList<Faction>> GetFactionsByIdsAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Retrieving factions by IDs from DAL...");
            var factions = await _politicsDal.GetFactionsByIds(ids, ct);
            return factions;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting factions by IDs.");
            throw;
        }
    }

    public async Task<IList<KnessetService.Models.Knesset>> GetKnessetsAsync(CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Retrieving knessets from DAL...");
            var knessets = await _politicsDal.GetKnessets(ct);
            return knessets;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting knessets.");
            throw;
        }
    }

    public async Task<IList<KnessetService.Models.Knesset>> GetKnessetsByIdsAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Retrieving knessets by IDs from DAL...");
            var knessets = await _politicsDal.GetKnessetsByIds(ids, ct);
            return knessets;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting knessets by IDs.");
            throw;
        }
    }
}
