using ClearDemocracy.KnessetService.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClearDemocracy.Knesset.Dal;

public class PoliticsDal : IPoliticsDal
{

    public Task<IList<MK>> InitMks(IList<MK> mks, CancellationToken ct = default)
    {
        throw new System.NotImplementedException();
    }
}
