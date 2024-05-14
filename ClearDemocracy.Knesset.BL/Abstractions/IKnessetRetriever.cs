using ClearDemocracy.KnessetService.Models;

namespace ClearDemocracy.Knesset.BL.Abstractions;

public interface IKnessetRetriever
{
    Task<IList<MK>> GetMksAsync(CancellationToken ct = default);

    Task<IList<MK>> GetMksByIdsAsync(IList<int> ids, CancellationToken ct = default);

    Task<IList<Faction>> GetFactionsAsync(CancellationToken ct = default);

    Task<IList<Faction>> GetFactionsByIdsAsync(IList<int> ids, CancellationToken ct = default);

    Task<IList<KnessetService.Models.Knesset>> GetKnessetsAsync(CancellationToken ct = default);

    Task<IList<KnessetService.Models.Knesset>> GetKnessetsByIdsAsync(IList<int> ids, CancellationToken ct = default);
}
