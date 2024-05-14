using ClearDemocracy.KnessetService.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClearDemocracy.Knesset.Dal;

public interface IPoliticsDal
{
    Task<IList<MK>> InitMks(IList<MK> mks, CancellationToken ct = default);
}