using Politics.BL.Models;

namespace Politics.BL.Abstractions;

public interface IPoliticsRetriever
{
    Task<IList<Mk>> GetMksAsync(CancellationToken ct = default);
    Task<IList<Mk>> GetMksByIdsAsync(IList<int> ids, CancellationToken ct = default);
    Task<IList<Faction>> GetFactionsAsync(CancellationToken ct = default);
    Task<IList<Faction>> GetFactionsByIdsAsync(IList<int> ids, CancellationToken ct = default);
    Task<IList<Knesset>> GetKnessetsAsync(CancellationToken ct = default);
    Task<IList<Knesset>> GetKnessetsByIdsAsync(IList<int> ids, CancellationToken ct = default);
    Task<IList<Government>> GetGovernmentsAsync(CancellationToken ct = default);
    Task<IList<Government>> GetGovernmentsByIdsAsync(IList<int> ids, CancellationToken ct = default);
    Task<IList<Minister>> GetMinistersAsync(CancellationToken ct = default);
    Task<IList<Minister>> GetMinistersByIdsAsync(IList<int> ids, CancellationToken ct = default);
}
