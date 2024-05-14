using ClearDemocracy.KnessetService.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClearDemocracy.Knesset.BL.Abstractions;

public interface IKnessetModifier
{
    Task<IList<MK>> InitMKs(CancellationToken ct = default);

    Task<IList<KnessetService.Models.Knesset>> InitKnessets(CancellationToken ct = default);

    Task<IList<Faction>> InitFactions(CancellationToken ct = default);
}