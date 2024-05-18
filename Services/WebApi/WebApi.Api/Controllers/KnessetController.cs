using KnessetService.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Api.Controllers;

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

    //[HttpGet("mksInit")]
    //public async Task<ActionResult<IList<MK>>> InitMksAsync(CancellationToken ct)
    //{
    //    try
    //    {
    //        var mks = await _knessetModifier.InitMKs(ct);
    //        return Ok(mks);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}

    //[HttpGet("factionsInit")]
    //public async Task<ActionResult<IList<Faction>>> InitFactionsAsync(CancellationToken ct)
    //{
    //    try
    //    {
    //        var factions = await _knessetModifier.InitFactions(ct);
    //        return Ok(factions);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}

    //[HttpGet("knessetsInit")]
    //public async Task<ActionResult<IList<Knesset>>> InitKnessetsAsync(CancellationToken ct)
    //{
    //    try
    //    {
    //        var knessets = await _knessetModifier.InitKnessets(ct);
    //        return Ok(knessets);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}

    //[HttpGet("governmentInit")]
    //public async Task<ActionResult> InitGovernmentAsync(CancellationToken ct)
    //{
    //    try
    //    {
    //        await _knessetModifier.InitGovernmentRoots(ct);
    //        return Ok();
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}
}
