using ClearDemocracy.KnessetService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClearDemocracy.Knesset.Dal;

public interface IPoliticsDal
{
    Task<IList<MK>> InitMks(IList<MK> mks, CancellationToken ct = default);
    Task<IList<Faction>> InitFactions(IList<Faction> factions, CancellationToken ct = default);
    Task<IList<KnessetService.Models.Knesset>> InitKnessets(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default);
    Task<IList<MK>> AddMks(IList<MK> mks, CancellationToken ct = default);
    Task<IList<MK>> UpdateMks(IList<MK> mks, CancellationToken ct = default);
    Task<IList<int>> DeleteMks(IList<int> ids, CancellationToken ct = default);
    Task<IList<Faction>> AddFactions(IList<Faction> factions, CancellationToken ct = default);
    Task<IList<Faction>> UpdateFactions(IList<Faction> factions, CancellationToken ct = default);
    Task<IList<int>> DeleteFactions(IList<int> ids, CancellationToken ct = default);
    Task<IList<KnessetService.Models.Knesset>> AddKnessets(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default);
    Task<IList<KnessetService.Models.Knesset>> UpdateKnessets(IList<KnessetService.Models.Knesset> knessets, CancellationToken ct = default);
    Task<IList<int>> DeleteKnessets(IList<int> ids, CancellationToken ct = default);
    Task<IList<MK>> GetAllMks(CancellationToken ct = default);
    Task<IList<MK>> GetMks(IList<int> ids, CancellationToken ct = default);
    Task<IList<Faction>> GetAllFactions(CancellationToken ct = default);
    Task<IList<Faction>> GetFactions(IList<int> ids, CancellationToken ct = default);
    Task<IList<KnessetService.Models.Knesset>> GetAllKnessets(CancellationToken ct = default);
    Task<IList<KnessetService.Models.Knesset>> GetKnessets(IList<int> ids, CancellationToken ct = default);
}
