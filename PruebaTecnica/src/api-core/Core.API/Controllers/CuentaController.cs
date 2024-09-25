using Core.API.Controllers.bases;
using Core.Application.models.cuenta;
using Core.Application.services.cuenta.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CuentaController : BaseController
  {
    private new readonly ILogger<CuentaController> _logger;
    private readonly ICuentaService _CuentaService;

    public CuentaController(ILogger<CuentaController> logger, ICuentaService CuentaService) : base(logger)
    {
      _logger = logger;
      _CuentaService = CuentaService;
    }

    [HttpGet("ObtenerPorId")]
    public IActionResult ObtenerPorId(int request)
    {
      try
      {
        var result = _CuentaService.ObtenerCuenta(request);
        if (result == null)
          return NotFound("Cuenta no ncontrada");
        _logger.LogInformation($"Cuenta encontrada {result}");
        return Ok($"Cuenta", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro crear Cuenta");
      }
    }
    [HttpPost("Crear")]
    public IActionResult Crear(CuentaCrearRequestModel request)
    {
      try
      {
        var result = _CuentaService.Crear(request);
        _logger.LogInformation($"Cuenta Creado {result}");
        return Ok($"Cuenta Creado", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro crear Cuenta");
      }
    }
    [HttpPut("Actualizar")]
    public IActionResult Actualizar(CuentaEditarRequestModel request)
    {
      try
      {
        var id = _CuentaService.Actualizar(request);
        _logger.LogInformation($"Cuenta Actualizado {request}");
        return Ok($"Cuenta Actualizado", id);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro actualizar Cuenta");
      }
    }
    [HttpDelete("Eliminar")]
    public IActionResult Eliminar(string request)
    {
      try
      {
        var result = _CuentaService.Eliminar(request);
        _logger.LogInformation($"Cuenta eliminada {request}");
        return Ok($"Cuenta eliminada", result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.Message);
        return BadRequest("No se logro eliminar Cuenta");
      }
    }

  }
}