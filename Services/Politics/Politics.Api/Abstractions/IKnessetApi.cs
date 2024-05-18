using Politics.BL.Models;

namespace Politics.Api.Abstractions;

public interface IKnessetApi
{
    Task<IList<Mk>> InitMkLobbyData(CancellationToken ct = default);

    Task<(IList<Faction> factions, IList<Knesset> knessets)> InitFactionsAndKnessets(CancellationToken ct = default);

    Task<(IList<Government> governments, IList<Minister> ministers)> InitGovernmentById(int governmentId, CancellationToken ct = default);
}