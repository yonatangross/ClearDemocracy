using ClearDemocracy.KnessetService.Models;

namespace ClearDemocracy.KnessetService.Abstractions;

public interface IKnessetApi
{
    Task<IList<MK>> GetMkLobbyData(CancellationToken ct = default);

    Task<IList<Faction>> GetFactions(CancellationToken ct = default);

    Task<IList<Models.Knesset>> GetKnessets(CancellationToken ct = default);
}