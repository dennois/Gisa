using Gisa.Domain;
using Gisa.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluxoController : ControllerBase
    {
        public FluxoController(IFluxoService fluxoService)
        {
            _fluxoService = fluxoService;
        }

        readonly IFluxoService _fluxoService;

        [HttpPost]
        public async Task<ActionResult<Fluxo>> Post([FromBody] Fluxo fluxo)
        {
            try
            {
                _fluxoService.IncluirAsync(fluxo);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return (ActionResult)Ok(fluxo);
        }
    }
}
