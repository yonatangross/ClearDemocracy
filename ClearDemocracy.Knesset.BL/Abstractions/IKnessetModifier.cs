using ClearDemocracy.KnessetService.Api.Models;

namespace ClearDemocracy.Knesset.BL.Abstractions;

public interface IKnessetModifier
{
    Task<IList<MK>> InitMKs(CancellationToken ct = default);
    Task<IList<KnessetService.Api.Models.Knesset>> InitKnessets(CancellationToken ct = default);
    Task<IList<Faction>> InitFactions(CancellationToken ct = default);
    Task<GovernmentRoot> InitGovernmentRoots(CancellationToken ct = default);
    Task AddMksAsync(IList<MK> mks, CancellationToken ct = default);
    Task UpdateMksAsync(IList<MK> mks, CancellationToken ct = default);
    Task DeleteMksAsync(IList<int> ids, CancellationToken ct = default);
    Task AddFactionsAsync(IList<Faction> factions, CancellationToken ct = default);
    Task UpdateFactionsAsync(IList<Faction> factions, CancellationToken ct = default);
    Task DeleteFactionsAsync(IList<int> ids, CancellationToken ct = default);
    Task AddKnessetsAsync(IList<KnessetService.Api.Models.Knesset> knessets, CancellationToken ct = default);
    Task UpdateKnessetsAsync(IList<KnessetService.Api.Models.Knesset> knessets, CancellationToken ct = default);
    Task DeleteKnessetsAsync(IList<int> ids, CancellationToken ct = default);
    Task AddGovernmentsAsync(IList<Government> governments, CancellationToken ct = default);
    Task UpdateGovernmentsAsync(IList<Government> governments, CancellationToken ct = default);
    Task DeleteGovernmentsAsync(IList<int> ids, CancellationToken ct = default);
    Task AddMinistersAsync(IList<Minister> ministers, CancellationToken ct = default);
    Task UpdateMinistersAsync(IList<Minister> ministers, CancellationToken ct = default);
    Task DeleteMinistersAsync(IList<int> ids, CancellationToken ct = default);
    Task AddMinisterLastPositionsAsync(IList<MinisterLastPosition> ministerLastPositions, CancellationToken ct = default);
    Task UpdateMinisterLastPositionsAsync(IList<MinisterLastPosition> ministerLastPositions, CancellationToken ct = default);
    Task DeleteMinisterLastPositionsAsync(IList<int> ids, CancellationToken ct = default);
}