using ClearDemocracy.KnessetService.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClearDemocracy.Knesset.Dal;

public interface IPoliticsDal
{
    Task<IList<MK>> InitMks(IList<MK> mks, CancellationToken ct = default);
    Task<IList<MK>> GetMks(IList<int> ids, CancellationToken ct = default);
    Task<IList<MK>> GetAllMks(CancellationToken ct = default);
    Task<IList<Faction>> InitFactions(IList<Faction> factions, CancellationToken ct = default);
    Task<IList<Faction>> GetFactions(CancellationToken ct = default);
    Task<IList<Faction>> GetFactionsByIds(IList<int> ids, CancellationToken ct = default);
    Task<IList<KnessetService.Models.Knesset>> InitKnessets(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default);
    Task<IList<KnessetService.Models.Knesset>> GetKnessets(CancellationToken ct = default);
    Task<IList<KnessetService.Models.Knesset>> GetKnessetsByIds(IList<int> ids, CancellationToken ct = default);
    Task AddMks(IList<MK> mks, CancellationToken ct = default);
    Task UpdateMks(IList<MK> mks, CancellationToken ct = default);
    Task DeleteMks(IList<int> ids, CancellationToken ct = default);
    Task AddFactions(IList<Faction> factions, CancellationToken ct = default);
    Task UpdateFactions(IList<Faction> factions, CancellationToken ct = default);
    Task DeleteFactions(IList<int> ids, CancellationToken ct = default);
    Task AddKnessets(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default);
    Task UpdateKnessets(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default);
    Task DeleteKnessets(IList<int> ids, CancellationToken ct = default);
}
