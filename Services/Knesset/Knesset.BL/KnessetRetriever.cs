using KnessetService.BL.Abstractions;
using KnessetService.Dal;
using Microsoft.Extensions.Logging;

namespace KnessetService.BL;

public class KnessetRetriever : IKnessetRetriever
{
    private readonly IPoliticsDal _politicsDal;
    private readonly ILogger<KnessetRetriever> _logger;

    public KnessetRetriever(ILogger<KnessetRetriever> logger, IPoliticsDal politicsDal)
    {
        _logger = logger;
        _politicsDal = politicsDal;
    }

    //public async Task<IList<MK>> GetMksAsync(CancellationToken ct = default)
    //{
    //    try
    //    {
    //        _logger.LogInformation("Retrieving all MKs from DAL...");
    //        var mks = await _politicsDal.GetAllMks(ct);
    //        return mks;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error occurred while getting all MKs.");
    //        throw;
    //    }
    //}

    //public async Task<IList<MK>> GetMksByIdsAsync(IList<int> ids, CancellationToken ct = default)
    //{
    //    try
    //    {
    //        _logger.LogInformation("Retrieving MKs by IDs from DAL...");
    //        var mks = await _politicsDal.GetMks(ids, ct);
    //        return mks;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error occurred while getting MKs by IDs.");
    //        throw;
    //    }
    //}

    //public async Task<IList<Faction>> GetFactionsAsync(CancellationToken ct = default)
    //{
    //    try
    //    {
    //        _logger.LogInformation("Retrieving factions from DAL...");
    //        var factions = await _politicsDal.GetAllFactions(ct);
    //        return factions;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error occurred while getting factions.");
    //        throw;
    //    }
    //}

    //public async Task<IList<Faction>> GetFactionsByIdsAsync(IList<int> ids, CancellationToken ct = default)
    //{
    //    try
    //    {
    //        _logger.LogInformation("Retrieving factions by IDs from DAL...");
    //        var factions = await _politicsDal.GetFactions(ids, ct);
    //        return factions;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error occurred while getting factions by IDs.");
    //        throw;
    //    }
    //}

    //public async Task<IList<Knesset>> GetKnessetsAsync(CancellationToken ct = default)
    //{
    //    try
    //    {
    //        _logger.LogInformation("Retrieving knessets from DAL...");
    //        var knessets = await _politicsDal.GetAllKnessets(ct);
    //        return knessets;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error occurred while getting knessets.");
    //        throw;
    //    }
    //}

    //public async Task<IList<Knesset>> GetKnessetsByIdsAsync(IList<int> ids, CancellationToken ct = default)
    //{
    //    try
    //    {
    //        _logger.LogInformation("Retrieving knessets by IDs from DAL...");
    //        var knessets = await _politicsDal.GetKnessets(ids, ct);
    //        return knessets;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error occurred while getting knessets by IDs.");
    //        throw;
    //    }
    //}

    //public Task<GovernmentRoot> GetGovernmentRootsAsync(CancellationToken ct = default)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<IList<Government>> GetGovernmentsAsync(CancellationToken ct = default)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<IList<Government>> GetGovernmentsByIdsAsync(IList<int> ids, CancellationToken ct = default)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<IList<Minister>> GetMinistersAsync(CancellationToken ct = default)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<IList<Minister>> GetMinistersByIdsAsync(IList<int> ids, CancellationToken ct = default)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<IList<MinisterLastPosition>> GetMinisterLastPositionsAsync(CancellationToken ct = default)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<IList<MinisterLastPosition>> GetMinisterLastPositionsByIdsAsync(IList<int> ids, CancellationToken ct = default)
    //{
    //    throw new NotImplementedException();
    //}
}
