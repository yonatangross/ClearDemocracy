
using ClearDemocracy.KnessetService.Models;

namespace ClearDemocracy.Knesset.BL.Abstractions;

public interface IKnessetModifier
{
    Task<IList<MK>> InitMKs(CancellationToken ct = default);

    Task<IList<KnessetService.Models.Knesset>> InitKnessets(CancellationToken ct = default);

    Task<IList<Faction>> InitFactions(CancellationToken ct = default);
}