using ClearDemocracy.KnessetService.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClearDemocracy.KnessetService.Abstractions;

public interface IKnessetApi
{
    Task<IList<MK>> GetMkLobbyData(CancellationToken ct = default);

    Task<IList<Faction>> GetFactions(CancellationToken ct = default);

    Task<IList<Knesset>> GetKnessets(CancellationToken ct = default);
}