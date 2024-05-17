using ClearDemocracy.KnessetService.Api.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClearDemocracy.Knesset.Dal;

public interface IPoliticsDal
{
    Task<IList<MK>> InitMks(IList<MK> mks, CancellationToken ct = default);
    Task<IList<Faction>> InitFactions(IList<Faction> factions, CancellationToken ct = default);
    Task<IList<Knesset>> InitKnessets(IList<Knesset> knessets, CancellationToken ct = default);
    Task<IList<MK>> AddMks(IList<MK> mks, CancellationToken ct = default);
    Task<IList<MK>> UpdateMks(IList<MK> mks, CancellationToken ct = default);
    Task<IList<int>> DeleteMks(IList<int> ids, CancellationToken ct = default);
    Task<IList<Faction>> AddFactions(IList<Faction> factions, CancellationToken ct = default);
    Task<IList<Faction>> UpdateFactions(IList<Faction> factions, CancellationToken ct = default);
    Task<IList<int>> DeleteFactions(IList<int> ids, CancellationToken ct = default);
    Task<IList<KnessetService.Api.Models.Knesset>> AddKnessets(IList<KnessetService.Api.Models.Knesset> knessets, CancellationToken ct = default);
    Task<IList<KnessetService.Api.Models.Knesset>> UpdateKnessets(IList<KnessetService.Api.Models.Knesset> knessets, CancellationToken ct = default);
    Task<IList<int>> DeleteKnessets(IList<int> ids, CancellationToken ct = default);
    Task<IList<MK>> GetAllMks(CancellationToken ct = default);
    Task<IList<MK>> GetMks(IList<int> ids, CancellationToken ct = default);
    Task<IList<Faction>> GetAllFactions(CancellationToken ct = default);
    Task<IList<Faction>> GetFactions(IList<int> ids, CancellationToken ct = default);
    Task<IList<KnessetService.Api.Models.Knesset>> GetAllKnessets(CancellationToken ct = default);
    Task<IList<KnessetService.Api.Models.Knesset>> GetKnessets(IList<int> ids, CancellationToken ct = default);
    Task<IList<Minister>> InitMinisters(IList<Minister> ministers, CancellationToken ct = default);
    Task<IList<Government>> InitGovernments(IList<Government> governments, CancellationToken ct = default);
    Task<IList<Minister>> AddMinisters(IList<Minister> ministers, CancellationToken ct = default);
    Task<IList<Minister>> UpdateMinisters(IList<Minister> ministers, CancellationToken ct = default);
    Task<IList<int>> DeleteMinisters(IList<int> ids, CancellationToken ct = default);
    Task<IList<Government>> AddGovernments(IList<Government> governments, CancellationToken ct = default);
    Task<IList<Government>> UpdateGovernments(IList<Government> governments, CancellationToken ct = default);
    Task<IList<int>> DeleteGovernments(IList<int> ids, CancellationToken ct = default);
    Task<IList<Minister>> GetAllMinisters(CancellationToken ct = default);
    Task<IList<Minister>> GetMinisters(IList<int> ids, CancellationToken ct = default);
    Task<IList<Government>> GetAllGovernments(CancellationToken ct = default);
    Task<IList<Government>> GetGovernments(IList<int> ids, CancellationToken ct = default);

}
