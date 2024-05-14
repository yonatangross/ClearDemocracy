using ClearDemocracy.Knesset.BL.Abstractions;
using ClearDemocracy.Knesset.Dal;
using ClearDemocracy.KnessetService.Abstractions;
using ClearDemocracy.KnessetService.Models;
using Microsoft.Extensions.Logging;

namespace ClearDemocracy.Knesset.BL;

public class KnessetModifier : IKnessetModifier
{
    private readonly IKnessetApi _knessetApi;
    private readonly IPoliticsDal _politicsDal;
    private readonly ILogger<KnessetModifier> _logger;

    public KnessetModifier(IKnessetApi knessetApi, ILogger<KnessetModifier> logger, IPoliticsDal politicsDal)
    {
        _knessetApi = knessetApi;
        _logger = logger;
        _politicsDal = politicsDal;
    }

    public async Task<IList<Faction>> InitFactions(CancellationToken ct = default)
    {
        try
        {
            var factions = await _knessetApi.GetFactions(ct);

            if (factions == null)
            {
                _logger.LogError("Failed to retrieve factions from Knesset API");
            }

            var result = await _politicsDal.InitFactions(factions, ct);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing factions");
            throw; // rethrow the exception if you want it to be handled further up the call stack
        }
    }

    public async Task<IList<KnessetService.Models.Knesset>> InitKnessets(CancellationToken ct = default)
    {
        try
        {
            var knessets = await _knessetApi.GetKnessets(ct);

            if (knessets == null)
            {
                _logger.LogError("Failed to retrieve Knessets from Knesset API");
            }

            var result = await _politicsDal.InitKnessets(knessets, ct);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing Knessets");
            throw; // rethrow the exception if you want it to be handled further up the call stack
        }
    }

    public async Task<IList<MK>> InitMKs(CancellationToken ct = default)
    {
        try
        {
            var mks = await _knessetApi.GetMkLobbyData(ct);

            if (mks == null)
            {
                _logger.LogError("Failed to retrieve MKs from Knesset API");
                return null;
            }

            var result = await _politicsDal.InitMks(mks, ct);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing MKs");
            throw; // rethrow the exception if you want it to be handled further up the call stack
        }
    }

    public async Task AddMksAsync(IList<MK> mks, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Adding MKs to DAL...");
            await _politicsDal.AddMks(mks, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding MKs.");
            throw;
        }
    }

    public async Task UpdateMksAsync(IList<MK> mks, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Updating MKs in DAL...");
            await _politicsDal.UpdateMks(mks, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating MKs.");
            throw;
        }
    }

    public async Task DeleteMksAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Deleting MKs from DAL...");
            await _politicsDal.DeleteMks(ids, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting MKs.");
            throw;
        }
    }

    public async Task<IList<Faction>> GetFactions(CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Retrieving factions from DAL...");
            var factions = await _politicsDal.GetAllFactions(ct);
            return factions;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting factions.");
            throw;
        }
    }

    public async Task AddFactionsAsync(IList<Faction> factions, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Adding factions to DAL...");
            await _politicsDal.InitFactions(factions, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding factions.");
            throw;
        }
    }

    public async Task UpdateFactionsAsync(IList<Faction> factions, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Updating factions in DAL...");
            await _politicsDal.InitFactions(factions, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating factions.");
            throw;
        }
    }

    public async Task DeleteFactionsAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Deleting factions from DAL...");
            await _politicsDal.DeleteFactions(ids, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting factions.");
            throw;
        }
    }

    public async Task AddKnessetsAsync(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Adding Knessets to DAL...");
            await _politicsDal.InitKnessets(knessets, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding Knessets.");
            throw;
        }
    }

    public async Task UpdateKnessetsAsync(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Updating Knessets in DAL...");
            await _politicsDal.InitKnessets(knessets, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating Knessets.");
            throw;
        }
    }

    public async Task DeleteKnessetsAsync(IList<int> ids, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Deleting Knessets from DAL...");
            await _politicsDal.DeleteKnessets(ids, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting Knessets.");
            throw;
        }
    }

    public async Task<IList<KnessetService.Models.Knesset>> GetKnessets(CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("Retrieving Knessets from DAL...");
            var knessets = await _politicsDal.GetAllKnessets(ct);
            return knessets;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting Knessets.");
            throw;
        }
    }
}
