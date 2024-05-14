using ClearDemocracy.Knesset.BL.Abstractions;
using ClearDemocracy.KnessetService;
using ClearDemocracy.KnessetService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClearDemocracy.Politics.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class KnessetController : ControllerBase
{
    private readonly IKnessetModifier _knessetModifier;
    private readonly IKnessetRetriever _knessetRetriever;

    public KnessetController(IKnessetModifier knessetModifier, IKnessetRetriever knessetRetriever)
    {
        _knessetModifier = knessetModifier;
        _knessetRetriever = knessetRetriever;
    }

    [HttpGet("mks")]
    public async Task<ActionResult<IList<MK>>> GetAllMksAsync(CancellationToken ct)
    {
        try
        {
            var mks = await _knessetRetriever.GetMksAsync(ct);
            return Ok(mks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("mks/{ids}")]
    public async Task<ActionResult<IList<MK>>> GetMksByIdsAsync([FromRoute] IList<int> ids, CancellationToken ct)
    {
        try
        {
            var mks = await _knessetRetriever.GetMksByIdsAsync(ids, ct);
            return Ok(mks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("mks")]
    public async Task<ActionResult> AddMksAsync([FromBody] IList<MK> mks, CancellationToken ct)
    {
        try
        {
            await _knessetModifier.AddMksAsync(mks, ct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("mks")]
    public async Task<ActionResult> UpdateMksAsync([FromBody] IList<MK> mks, CancellationToken ct)
    {
        try
        {
            await _knessetModifier.UpdateMksAsync(mks, ct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("mks/{ids}")]
    public async Task<ActionResult> DeleteMksAsync([FromRoute] IList<int> ids, CancellationToken ct)
    {
        try
        {
            await _knessetModifier.DeleteMksAsync(ids, ct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("factions")]
    public async Task<ActionResult<IList<Faction>>> GetFactionsAsync(CancellationToken ct)
    {
        try
        {
            var factions = await _knessetRetriever.GetFactionsAsync(ct);
            return Ok(factions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("factions/{ids}")]
    public async Task<ActionResult<IList<Faction>>> GetFactionsByIdsAsync([FromRoute] IList<int> ids, CancellationToken ct)
    {
        try
        {
            var factions = await _knessetRetriever.GetFactionsByIdsAsync(ids, ct);
            return Ok(factions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("knessets")]
    public async Task<ActionResult<IList<KnessetService.Models.Knesset>>> GetKnessetsAsync(CancellationToken ct)
    {
        try
        {
            var knessets = await _knessetRetriever.GetKnessetsAsync(ct);
            return Ok(knessets);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("mksInit")]
    public async Task<ActionResult<IList<MK>>> InitMksAsync(CancellationToken ct)
    {
        try
        {
            var mks = await _knessetModifier.InitMKs(ct);
            return Ok(mks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("factionsInit")]
    public async Task<ActionResult<IList<Faction>>> InitFactionsAsync(CancellationToken ct)
    {
        try
        {
            var factions = await _knessetModifier.InitFactions(ct);
            return Ok(factions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("knessetsInit")]
    public async Task<ActionResult<IList<KnessetService.Models.Knesset>>> InitKnessetsAsync(CancellationToken ct)
    {
        try
        {
            var knessets = await _knessetModifier.InitKnessets(ct);
            return Ok(knessets);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("factions")]
    public async Task<ActionResult> AddFactionsAsync([FromBody] IList<Faction> factions, CancellationToken ct)
    {
        try
        {
            await _knessetModifier.AddFactionsAsync(factions, ct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("factions")]
    public async Task<ActionResult> UpdateFactionsAsync([FromBody] IList<Faction> factions, CancellationToken ct)
    {
        try
        {
            await _knessetModifier.UpdateFactionsAsync(factions, ct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("factions/{ids}")]
    public async Task<ActionResult> DeleteFactionsAsync([FromRoute] IList<int> ids, CancellationToken ct)
    {
        try
        {
            await _knessetModifier.DeleteFactionsAsync(ids, ct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("knessets")]
    public async Task<ActionResult> AddKnessetsAsync([FromBody] IList<KnessetService.Models.Knesset> knessets, CancellationToken ct)
    {
        try
        {
            await _knessetModifier.AddKnessetsAsync(knessets, ct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("knessets")]
    public async Task<ActionResult> UpdateKnessetsAsync([FromBody] IList<KnessetService.Models.Knesset> knessets, CancellationToken ct)
    {
        try
        {
            await _knessetModifier.UpdateKnessetsAsync(knessets, ct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("knessets/{ids}")]
    public async Task<ActionResult> DeleteKnessetsAsync([FromRoute] IList<int> ids, CancellationToken ct)
    {
        try
        {
            await _knessetModifier.DeleteKnessetsAsync(ids, ct);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
