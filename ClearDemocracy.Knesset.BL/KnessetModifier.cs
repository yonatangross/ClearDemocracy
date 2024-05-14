using ClearDemocracy.Knesset.BL.Abstractions;
using ClearDemocracy.Knesset.Dal;
using ClearDemocracy.KnessetService.Abstractions;
using ClearDemocracy.KnessetService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        var factions = await _knessetApi.GetFactions(ct);

        if (factions == null)
        {
            _logger.LogError("Failed to retrieve factions from Knesset API");
        }

        return factions;
    }

    public Task<IList<KnessetService.Models.Knesset>> InitKnessets(CancellationToken ct = default)
    {
        throw new NotImplementedException();
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
}
