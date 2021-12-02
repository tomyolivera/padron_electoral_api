using Microsoft.AspNetCore.Mvc;
using PadronAPI.Models;
using PadronAPI.Services;

namespace PadronAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PadronController : ControllerBase
    {
        [HttpGet("api/{dni}")]
        public ActionResult<Persona> Get(int dni)
        {
            Persona Persona = PersonaService.Get(dni);

            if(Persona == null)
                return NotFound();

            return Persona;
        }

        [HttpPost("api/votar")]
        public ActionResult<Persona> Votar(Voto voto)
        {
            Persona Persona = PersonaService.Get(voto.DNI);

            if(Persona == null)
                return NotFound();

            if(Persona.NumeroTramite != voto.NumeroTramite)
                return BadRequest();

            PersonaService.Votar(voto);
            
            return Ok();
        }

    }
}
