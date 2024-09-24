using AutoMapper;
using Core.Application.models.movimiento;
using Core.Application.services.movimiento.interfaces;
using Core.Domain.repositories.interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.entities;

namespace Core.Application.services.movimiento
{
  public class MovimientoService:IMovimientoService
  {
    private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  private readonly ILogger<MovimientoService> _logger;

  public MovimientoService(IUnitOfWork unitOfWork, IMapper mapper,
      ILogger<MovimientoService> logger)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
    _logger = logger;
  }

  /// <summary>
  /// Para este caso de actualizacion del model request es similar al de la entidad sin embargo si se aplicara auditoria se podria controlar los campos adicionales (quien actualizo y fecha de actualizacion)
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>
  public bool Actualizar(MovimientoEditarRequestModel request)
  {
    try
    {
      MovimientoEntity MovimientoEntity = new MovimientoEntity();

      IMovimientoDomainRepository repository = _unitOfWork.GetMovimientoRepository();
      _mapper.Map(request, MovimientoEntity);
      repository.UpdateAsync(MovimientoEntity);
      _unitOfWork.SaveSync();
      return true;
    }
    catch
    {
      //salta al catch principal
      throw;
    }

  }
  /// <summary>
  /// La creacion de Movimiento es mediante un model request que obtiene solo los parameetros necesarios
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>

  public int Crear(MovimientoCrearRequestModel request)
  {
    try
    {
      MovimientoEntity MovimientoEntity = new MovimientoEntity();
      IMovimientoDomainRepository repository = _unitOfWork.GetMovimientoRepository();
      _mapper.Map(request, MovimientoEntity);
      repository.AddSync(MovimientoEntity);
      _unitOfWork.SaveSync();
      return MovimientoEntity.Id;
    }
    catch
    {
      //salta al catch principal
      throw;
    }
  }

  /// <summary>
  /// Para este caso el eliminado si es fisico pero se puede considerar el eliminado logico acorde a una defincion de auditoria en control de cambios posibles a la prueba de concepto
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>
  public bool Eliminar(int request)
  {
    try
    {
      MovimientoEntity MovimientoEntity = new MovimientoEntity();
      IMovimientoDomainRepository repository = _unitOfWork.GetMovimientoRepository();
      MovimientoEntity = repository.FirstOrDefaultSync(x => x.Id.Equals(request));
      repository.RemoveAsync(MovimientoEntity);
      _unitOfWork.SaveSync();
      return true;
    }
    catch
    {
      //salta al catch principal
      throw;
    }
  }

  public MovimientoRequestModel ObtenerMovimiento(int request)
  {
    try
    {
      MovimientoRequestModel resultado = new MovimientoRequestModel();
      MovimientoEntity MovimientoEntity = new MovimientoEntity();
      IMovimientoDomainRepository repository = _unitOfWork.GetMovimientoRepository();
      MovimientoEntity = repository.FirstOrDefaultSync(x => x.Id.Equals(request));

      resultado = _mapper.Map<MovimientoRequestModel>(MovimientoEntity);
      return resultado;
    }
    catch
    {
      //salta al catch principal
      throw;
    }
  }
}
}