using KnessetService.BL.Models;

namespace KnessetService.BL.Abstractions;

public interface IKnessetModifier
{
    Task<IList<Mk>> InitMkLobbyData(CancellationToken ct = default);
    Task<IList<Faction>> InitFactions(CancellationToken ct = default);
    Task<IList<Knesset>> InitKnessets(CancellationToken ct = default);
    Task<(IList<Government> governments, IList<Minister> ministers)> InitGovernmentById(int governmentId, CancellationToken ct = default);
}