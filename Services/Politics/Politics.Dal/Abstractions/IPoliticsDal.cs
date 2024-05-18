using Politics.BL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Politics.Dal.Abstractions;

public interface IPoliticsDal
{
    // Create Methods
    Task<IList<Faction>> InitFactions(IList<Models.Faction> factions, CancellationToken ct);
    Task<IList<Government>> InitGovernments(IList<Models.Government> governments, CancellationToken ct);
    Task<IList<Knesset>> InitKnessets(IList<Models.Knesset> knessets, CancellationToken ct);
    Task<IList<Minister>> InitMinisters(IList<Models.Minister> ministers, CancellationToken ct);
    Task<IList<Mk>> InitMks(IList<Models.Mk> mks, CancellationToken ct);

    // Read Methods
    Task<IList<Faction>> GetFactions(CancellationToken ct = default);
    Task<IList<Government>> GetGovernments(CancellationToken ct = default);
    Task<IList<Knesset>> GetKnessets(CancellationToken ct = default);
    Task<IList<Minister>> GetMinisters(CancellationToken ct = default);
    Task<IList<Mk>> GetMks(CancellationToken ct = default);

    // Update Methods
    Task<Faction> UpdateFaction(Models.Faction faction, CancellationToken ct = default);
    Task<Government> UpdateGovernment(Models.Government government, CancellationToken ct = default);
    Task<Knesset> UpdateKnesset(Models.Knesset knesset, CancellationToken ct = default);
    Task<Minister> UpdateMinister(Models.Minister minister, CancellationToken ct = default);
    Task<Mk> UpdateMk(Models.Mk mk, CancellationToken ct = default);

    // Delete Methods
    Task<bool> DeleteFaction(int id, CancellationToken ct = default);
    Task<bool> DeleteGovernment(int id, CancellationToken ct = default);
    Task<bool> DeleteKnesset(int id, CancellationToken ct = default);
    Task<bool> DeleteMinister(int id, CancellationToken ct = default);
    Task<bool> DeleteMk(int id, CancellationToken ct = default);
}
