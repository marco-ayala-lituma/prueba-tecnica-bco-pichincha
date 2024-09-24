using Microsoft.AspNetCore.Mvc;
using Tecrero.Application.models.cliente;
using Tecrero.Application.services.cliente.interfaces;
using Tercero.API.Controllers.bases;

namespace Tercero.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClienteController : BaseController
  {
    private new readonly ILogger<ClienteController> _logger;
    private readonly IClienteService _ClienteService;

    public ClienteController(ILogger<ClienteController> logger, IClienteService ClienteService) : base(logger)
    {
      _logger = logger;
      _ClienteService = ClienteService;
    }

    [HttpGet("ObtenerPorId")]
    public IActionResult ObtenerPorId(int request)
    {
      try
      {
        var result = _ClienteService.ObtenerCliente(request);
        if (result == null)
          return NotFound("Cliente no ncontrada");
        _logger.LogInformation($"Cliente encontrada {result}");
        return Ok($"Cliente", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro crear Cliente");
      }
    }
    [HttpPost("Crear")]
    public IActionResult Crear(ClienteCrearRequestModel request)
    {
      try
      {
        var result = _ClienteService.Crear(request);
        _logger.LogInformation($"Cliente Creado {result}");
        return Ok($"Cliente Creado", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro crear Cliente");
      }
    }
    [HttpPut("Actualizar")]
    public IActionResult Actualizar(ClienteEditarRequestModel request)
    {
      try
      {
        var id = _ClienteService.Actualizar(request);
        _logger.LogInformation($"Cliente Actualizado {request}");
        return Ok($"Cliente Actualizado", id);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro actualizar Cliente");
      }
    }
    [HttpDelete("Eliminar")]
    public IActionResult Eliminar(int request)
    {
      try
      {
        var result = _ClienteService.Eliminar(request);
        _logger.LogInformation($"Cliente eliminada {request}");
        return Ok($"Cliente eliminada", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro eliminar Cliente");
      }
    }

  }
}

