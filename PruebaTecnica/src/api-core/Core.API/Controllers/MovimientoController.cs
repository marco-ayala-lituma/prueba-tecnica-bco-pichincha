using Core.API.Controllers.bases;
using Core.Application.models.cuenta;
using Core.Application.models.movimiento;
using Core.Application.services.movimiento.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MovimientoController : BaseController
  {
    private new readonly ILogger<MovimientoController> _logger;
    private readonly IMovimientoService _MovimientoService;

    public MovimientoController(ILogger<MovimientoController> logger, IMovimientoService MovimientoService) : base(logger)
    {
      _logger = logger;
      _MovimientoService = MovimientoService;
    }

    [HttpGet("ObtenerPorId")]
    public IActionResult ObtenerPorId(int request)
    {
      try
      {
        var result = _MovimientoService.ObtenerMovimiento(request);
        if (result == null)
          return NotFound("Movimiento no ncontrada");
        _logger.LogInformation($"Movimiento encontrada {result}");
        return Ok($"Movimiento", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro obtener Movimiento");
      }
    }
    [HttpPost("Crear")]
    public IActionResult Crear(MovimientoCrearRequestModel request)
    {
      try
      {
        var result = _MovimientoService.Crear(request);
        _logger.LogInformation($"Movimiento Creado {result}");
        return Ok($"Movimiento Creado", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest(ex.Message);
      }
    }
    [HttpPut("Actualizar")]
    public IActionResult Actualizar(MovimientoEditarRequestModel request)
    {
      try
      {
        var id = _MovimientoService.Actualizar(request);
        _logger.LogInformation($"Movimiento Actualizado {request}");
        return Ok($"Movimiento Actualizado", id);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro actualizar Movimiento");
      }
    }
    [HttpDelete("Eliminar")]
    public IActionResult Eliminar(int request)
    {
      try
      {
        var result = _MovimientoService.Eliminar(request);
        _logger.LogInformation($"Movimiento eliminada {request}");
        return Ok($"Movimiento eliminada", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro eliminar Movimiento");
      }
    }
    [HttpPost("Reporte")]
    public IActionResult Reporte(ClienteReporteRequestModel request)
    {
      try
      {
        var result = _MovimientoService.ObtenerReporteMovimientos(request);
        _logger.LogInformation($"Movimiento Creado {result}");
        return Ok($"Movimiento Creado", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest(ex.Message);
      }
    }
  }
}
