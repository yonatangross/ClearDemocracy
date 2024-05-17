using ClearDemocracy.KnessetService.Api.Models;

namespace ClearDemocracy.Knesset.BL.Abstractions;

public interface IKnessetRetriever
{
    Task<IList<MK>> GetMksAsync(CancellationToken ct = default);
    Task<IList<MK>> GetMksByIdsAsync(IList<int> ids, CancellationToken ct = default);
    Task<IList<Faction>> GetFactionsAsync(CancellationToken ct = default);
    Task<IList<Faction>> GetFactionsByIdsAsync(IList<int> ids, CancellationToken ct = default);
    Task<IList<KnessetService.Api.Models.Knesset>> GetKnessetsAsync(CancellationToken ct = default);
    Task<IList<KnessetService.Api.Models.Knesset>> GetKnessetsByIdsAsync(IList<int> ids, CancellationToken ct = default);
    Task<GovernmentRoot> GetGovernmentRootsAsync(CancellationToken ct = default);
    Task<IList<Government>> GetGovernmentsAsync(CancellationToken ct = default);
    Task<IList<Government>> GetGovernmentsByIdsAsync(IList<int> ids, CancellationToken ct = default);
    Task<IList<Minister>> GetMinistersAsync(CancellationToken ct = default);
    Task<IList<Minister>> GetMinistersByIdsAsync(IList<int> ids, CancellationToken ct = default);
    Task<IList<MinisterLastPosition>> GetMinisterLastPositionsAsync(CancellationToken ct = default);
    Task<IList<MinisterLastPosition>> GetMinisterLastPositionsByIdsAsync(IList<int> ids, CancellationToken ct = default);
}
