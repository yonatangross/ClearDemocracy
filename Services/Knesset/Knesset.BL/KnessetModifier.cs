using KnessetService.Api.Abstractions;
using KnessetService.Api.Options;
using KnessetService.BL.Abstractions;
using KnessetService.BL.Models;
using KnessetService.Dal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KnessetService.BL;

public class KnessetModifier : IKnessetModifier
{
    private readonly IPoliticsDal _politicsDal;
    private readonly IKnessetApi _knessetApi;
    private readonly QueryOptions _options;
    private readonly ILogger<KnessetModifier> _logger;

    public KnessetModifier(IKnessetApi knessetApi, ILogger<KnessetModifier> logger, IPoliticsDal politicsDal, IOptions<QueryOptions> options)
    {
        _knessetApi = knessetApi;
        _logger = logger;
        _politicsDal = politicsDal;
        _options = options.Value;
    }

    public Task<IList<Faction>> InitFactions(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<(IList<Government> governments, IList<Minister> ministers)> InitGovernmentById(int governmentId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Knesset>> InitKnessets(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Mk>> InitMkLobbyData(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
