using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tecrero.Application.models.persona;
using Tecrero.Application.services.persona.interfaces;
using Tercero.API.Controllers.bases;

namespace Tercero.API.Controllers
{
  //De momento no vamos a utilizar controles de seguridad para esta practica
  //[Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class PersonaController : BaseController
  {
    private new readonly ILogger<PersonaController> _logger;
    private readonly IPersonaService _personaService;

    public PersonaController(ILogger<PersonaController> logger, IPersonaService personaService) : base(logger)
    {
      _logger = logger;
      _personaService = personaService;
    }

    [HttpGet("ObtenerPorId")]
    public IActionResult ObtenerPorId() 
    {
      return null;
    }
    [HttpPost("Crear")]
    public IActionResult Crear(PersonaCrearRequestModel request)
    {
      try
      {
        _personaService.Crear(request);

        return Success();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

  }
}
