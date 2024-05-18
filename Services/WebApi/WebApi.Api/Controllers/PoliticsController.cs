using Microsoft.AspNetCore.Mvc;
using Politics.BL.Abstractions;
using Politics.BL.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoliticsService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PoliticsController : ControllerBase
{
    private readonly IPoliticsModifier _politicsModifier;
    private readonly IPoliticsRetriever _politicsRetriever;

    public PoliticsController(IPoliticsModifier politicsModifier, IPoliticsRetriever politicsRetriever)
    {
        _politicsModifier = politicsModifier;
        _politicsRetriever = politicsRetriever;
    }

    [HttpGet("mksInit")]
    public async Task<ActionResult<IList<Mk>>> InitMksAsync(CancellationToken ct = default)
    {
        try
        {
            var mks = await _politicsModifier.InitMkLobbyData(ct);
            return Ok(mks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("factionsAndKnessetsInit")]
    public async Task<ActionResult> InitFactionsAndKnessetsAsync(CancellationToken ct = default)
    {
        try
        {
            var (factions, knessets) = await _politicsModifier.InitFactionsAndKnessets(ct);
            return Ok(new { factions, knessets });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("governmentInit/{governmentId}")]
    public async Task<ActionResult> InitGovernmentAsync(int governmentId, CancellationToken ct = default)
    {
        try
        {
            var (governments, ministers) = await _politicsModifier.InitGovernmentById(governmentId, ct);
            return Ok(new { governments, ministers });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
