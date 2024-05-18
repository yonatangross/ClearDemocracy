using KnessetService.BL.Models;

namespace KnessetService.Api.Abstractions;

public interface IKnessetApi
{ 
    Task<IList<Mk>> InitMkLobbyData(CancellationToken ct = default);
    Task<IList<Faction>> InitFactions(CancellationToken ct = default);
    Task<IList<Knesset>> InitKnessets(CancellationToken ct = default);
    Task<(IList<Government> governments, IList<Minister> ministers)> InitGovernmentById(int governmentId, CancellationToken ct = default);
}