using Microsoft.AspNetCore.Mvc;
using Politics.BL.Abstractions;
using Politics.BL.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoliticsService.WebApi.Controllers
{
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

        [HttpGet("factionsInit")]
        public async Task<ActionResult<IList<Faction>>> InitFactionsAsync(CancellationToken ct = default)
        {
            try
            {
                var factions = await _politicsModifier.InitFactions(ct);
                return Ok(factions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("knessetsInit")]
        public async Task<ActionResult<IList<Knesset>>> InitKnessetsAsync(CancellationToken ct = default)
        {
            try
            {
                var knessets = await _politicsModifier.InitKnessets(ct);
                return Ok(knessets);
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
}
