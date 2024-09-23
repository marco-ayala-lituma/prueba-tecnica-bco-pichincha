using Azure.Core;
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
    public IActionResult ObtenerPorId(int request) 
    {
      try
      {
        var result = _personaService.ObtenerPersona(request);
        if (result == null)
          return NotFound("Persona no ncontrada");
        _logger.LogInformation($"Persona encontrada {result}");
        return Ok($"Persona", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro crear persona");
      }
    }
    [HttpPost("Crear")]
    public IActionResult Crear(PersonaCrearRequestModel request)
    {
      try
      {
        var result = _personaService.Crear(request);
        _logger.LogInformation($"Persona Creado {result}");
        return Ok($"Persona Creado", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro crear persona");
      }
    }
    [HttpPut("Actualizar")]
    public IActionResult Actualizar(PersonaEditarRequestModel request)
    {
      try
      {
        var id = _personaService.Actualizar(request);
        _logger.LogInformation($"Persona Actualizado {request}");
        return Ok($"Persona Actualizado", id);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro actualizar persona");
      }
    }
    [HttpDelete("Eliminar")]
    public IActionResult Eliminar(int request)
    {
      try
      {
        var result = _personaService.Eliminar(request);
        _logger.LogInformation($"Persona eliminada {request}");
        return Ok($"Persona eliminada", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro eliminar persona");
      }
    }

  }
}
