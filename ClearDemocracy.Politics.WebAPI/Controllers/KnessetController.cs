using ClearDemocracy.Knesset.BL.Abstractions;
using ClearDemocracy.KnessetService;
using ClearDemocracy.KnessetService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClearDemocracy.Politics.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class KnessetController : ControllerBase
{
    private readonly KnessetApi _knessetApi;
    private readonly IKnessetModifier _knessetModifier;

    public KnessetController(KnessetApi KnessetService, IKnessetModifier knessetModifier)
    {
        _knessetApi = KnessetService;
        _knessetModifier = knessetModifier;
    }

    [HttpGet("mks")]
    public async Task<ActionResult<IList<MK>>> GetAsync()
    {
        try
        {
            var mks = await _knessetApi.GetMkLobbyData();
            return Ok(mks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("mksInit")]
    public async Task<ActionResult<IList<MK>>> InitMksAsync()
    {
        try
        {
            var mks = await _knessetModifier.InitMKs();

            return Ok(mks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("factions")]
    public async Task<ActionResult<IList<Faction>>> GetFactionsAsync()
    {
        try
        {
            var factions = await _knessetApi.GetFactions();
            return Ok(factions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
