using ClearDemocracy.KnessetService.Api.Models;

namespace ClearDemocracy.KnessetService.Api.Abstractions;

public interface IKnessetApi
{
    Task<IList<MK>> GetMkLobbyData(CancellationToken ct = default);

    Task<IList<Faction>> GetFactions(CancellationToken ct = default);

    Task<IList<Knesset>> GetKnessets(CancellationToken ct = default);

    Task<GovernmentRoot> GetGovernmentRoot(int governmentId, CancellationToken ct = default);
}