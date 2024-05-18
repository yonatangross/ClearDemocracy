using Politics.BL.Models;

namespace Politics.BL.Abstractions;

public interface IPoliticsModifier
{
    // Create Methods
    Task<IList<Mk>> InitMkLobbyData(CancellationToken ct = default);
    Task<IList<Faction>> InitFactions(CancellationToken ct = default);
    Task<IList<Knesset>> InitKnessets(CancellationToken ct = default);
    Task<(IList<Government> governments, IList<Minister> ministers)> InitGovernmentById(int governmentId, CancellationToken ct = default);

    // Update Methods
    Task<Faction> UpdateFaction(Faction faction, CancellationToken ct = default);
    Task<Government> UpdateGovernment(Government government, CancellationToken ct = default);
    Task<Knesset> UpdateKnesset(Knesset knesset, CancellationToken ct = default);
    Task<Minister> UpdateMinister(Minister minister, CancellationToken ct = default);
    Task<Mk> UpdateMk(Mk mk, CancellationToken ct = default);

    // Delete Methods
    Task<bool> DeleteFaction(int id, CancellationToken ct = default);
    Task<bool> DeleteGovernment(int id, CancellationToken ct = default);
    Task<bool> DeleteKnesset(int id, CancellationToken ct = default);
    Task<bool> DeleteMinister(int id, CancellationToken ct = default);
    Task<bool> DeleteMk(int id, CancellationToken ct = default);
}
