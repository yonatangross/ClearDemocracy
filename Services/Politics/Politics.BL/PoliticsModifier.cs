using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Politics.Api.Abstractions;
using Politics.Api.Options;
using Politics.BL.Abstractions;
using Politics.BL.Models;
using Politics.Converter;
using Politics.Dal.Abstractions;

namespace Politics.BL;

public class PoliticsModifier : IPoliticsModifier
{
    private readonly IPoliticsDal _politicsDal;
    private readonly IKnessetApi _knessetApi;
    private readonly PoliticsQueryOptions _options;
    private readonly ILogger<PoliticsModifier> _logger;

    public PoliticsModifier(IKnessetApi knessetApi, ILogger<PoliticsModifier> logger, IPoliticsDal politicsDal, IOptions<PoliticsQueryOptions> options)
    {
        _knessetApi = knessetApi;
        _logger = logger;
        _politicsDal = politicsDal;
        _options = options.Value;
    }

    // Create Methods
    public async Task<(IList<Faction> factions, IList<Knesset> knessets)> InitFactionsAndKnessets(CancellationToken ct = default)
    {
        var (factions, knessets) = await _knessetApi.InitFactionsAndKnessets(ct);

        if (factions != null && knessets != null)
        {
            await _politicsDal.InitFactions(factions.Select(ModelConverter.ToDalModel).ToList(), ct);
            await _politicsDal.InitKnessets(knessets.Select(ModelConverter.ToDalModel).ToList(), ct);
            return (factions, knessets);
        }

        _logger.LogError("Failed to initialize factions and knessets.");
        return (null, null);
    }

    public async Task<(IList<Government> governments, IList<Minister> ministers)> InitGovernmentById(int governmentId, CancellationToken ct = default)
    {
        var (governments, ministers) = await _knessetApi.InitGovernmentById(governmentId, ct);
        if (governments != null && ministers != null)
        {
            var governmentsResult = await _politicsDal.InitGovernments(governments.Select(ModelConverter.ToDalModel).ToList(), ct);
            var ministersResult = await _politicsDal.InitMinisters(ministers.Select(ModelConverter.ToDalModel).ToList(), ct);
            return (governmentsResult, ministersResult);
        }
        _logger.LogError($"Failed to initialize government with ID {governmentId}.");
        return (null, null);
    }


    public async Task<IList<Mk>> InitMkLobbyData(CancellationToken ct = default)
    {
        var mks = await _knessetApi.InitMkLobbyData(ct);
        if (mks != null)
        {
            return await _politicsDal.InitMks(mks.Select(ModelConverter.ToDalModel).ToList(), ct);
        }
        _logger.LogError("Failed to initialize MK lobby data.");
        return null;
    }

    // Update Methods
    public async Task<Faction> UpdateFaction(Faction faction, CancellationToken ct = default)
    {
        return await _politicsDal.UpdateFaction(faction.ToDalModel(), ct);
    }

    public async Task<Government> UpdateGovernment(Government government, CancellationToken ct = default)
    {
        return await _politicsDal.UpdateGovernment(government.ToDalModel(), ct);

    }

    public async Task<Knesset> UpdateKnesset(Knesset knesset, CancellationToken ct = default)
    {
        return await _politicsDal.UpdateKnesset(knesset.ToDalModel(), ct);
    }

    public async Task<Minister> UpdateMinister(Minister minister, CancellationToken ct = default)
    {
        return await _politicsDal.UpdateMinister(minister.ToDalModel(), ct);
    }

    public async Task<Mk> UpdateMk(Mk mk, CancellationToken ct = default)
    {
        return await _politicsDal.UpdateMk(mk.ToDalModel(), ct);
    }

    // Delete Methods
    public async Task<bool> DeleteFaction(int id, CancellationToken ct = default)
    {
        try
        {
            return await _politicsDal.DeleteFaction(id, ct);
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
            return await _politicsDal.DeleteGovernment(id, ct);
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
            return await _politicsDal.DeleteKnesset(id, ct);
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
            return await _politicsDal.DeleteMinister(id, ct);
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
            return await _politicsDal.DeleteMk(id, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete MK: {ex.Message}");
            return false;
        }
    }
}
