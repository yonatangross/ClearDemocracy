using ClearDemocracy.KnessetService.Models;

namespace ClearDemocracy.Knesset.BL.Abstractions;

public interface IKnessetModifier
{
    Task<IList<MK>> InitMKs(CancellationToken ct = default);
    Task<IList<KnessetService.Models.Knesset>> InitKnessets(CancellationToken ct = default);
    Task<IList<Faction>> InitFactions(CancellationToken ct = default);
    Task AddMksAsync(IList<MK> mks, CancellationToken ct = default);
    Task UpdateMksAsync(IList<MK> mks, CancellationToken ct = default);
    Task DeleteMksAsync(IList<int> ids, CancellationToken ct = default);
    Task AddFactionsAsync(IList<Faction> factions, CancellationToken ct = default);
    Task UpdateFactionsAsync(IList<Faction> factions, CancellationToken ct = default);
    Task DeleteFactionsAsync(IList<int> ids, CancellationToken ct = default);
    Task AddKnessetsAsync(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default);
    Task UpdateKnessetsAsync(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default);
    Task DeleteKnessetsAsync(IList<int> ids, CancellationToken ct = default);
}