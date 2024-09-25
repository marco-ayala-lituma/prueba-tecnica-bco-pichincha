using AutoMapper;
using Core.Application.models.cuenta;
using Core.Application.services.cuenta.interfaces;
using Core.Domain.repositories.interfaces;
using Microsoft.Extensions.Logging;
using Core.Domain.entities;
using Core.Application.clients;

namespace Core.Application.services.cuenta
{
  public class CuentaService : ICuentaService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CuentaService> _logger;
    private readonly TerceroClient _terceroClient;
    public CuentaService(IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<CuentaService> logger,
        TerceroClient terceroClient)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _logger = logger;
      _terceroClient = terceroClient;
    }

    /// <summary>
    /// Para este caso de actualizacion del model request es similar al de la entidad sin embargo si se aplicara auditoria se podria controlar los campos adicionales (quien actualizo y fecha de actualizacion)
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public bool Actualizar(CuentaEditarRequestModel request)
    {
      try
      {
        if (_terceroClient.Enviar(request.ClienteId).Data.ClienteId == 0)
        {
          new Exception("Cliente No existe");
        }
        CuentaEntity CuentaEntity = new CuentaEntity();
        ICuentaDomainRepository repository = _unitOfWork.GetCuentaRepository();
        _mapper.Map(request, CuentaEntity);
        repository.UpdateAsync(CuentaEntity);
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
    /// La creacion de Cuenta es mediante un model request que obtiene solo los parameetros necesarios
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>

    public string Crear(CuentaCrearRequestModel request)
    {
      try
      {
        if (_terceroClient.Enviar(request.ClienteId).Data.ClienteId == 0)
          throw new Exception("Client no existe");
        
        CuentaEntity CuentaEntity = new CuentaEntity();
        ICuentaDomainRepository repository = _unitOfWork.GetCuentaRepository();
        _mapper.Map(request, CuentaEntity);
        repository.AddSync(CuentaEntity);
        _unitOfWork.SaveSync();
        return CuentaEntity.NumeroCuenta;
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
    public bool Eliminar(string request)
    {
      try
      {
        CuentaEntity CuentaEntity = new CuentaEntity();
        ICuentaDomainRepository repository = _unitOfWork.GetCuentaRepository();
        CuentaEntity = repository.FirstOrDefaultSync(x => x.NumeroCuenta == request);
        repository.RemoveAsync(CuentaEntity);
        _unitOfWork.SaveSync();
        return true;
      }
      catch
      {
        //salta al catch principal
        throw;
      }
    }

    public CuentaRequestModel ObtenerCuenta(int request)
    {
      try
      {
        CuentaRequestModel resultado = new CuentaRequestModel();
        CuentaEntity CuentaEntity = new CuentaEntity();
        ICuentaDomainRepository repository = _unitOfWork.GetCuentaRepository();
        CuentaEntity = repository.FirstOrDefaultSync(x => x.NumeroCuenta.Equals(request));

        resultado = _mapper.Map<CuentaRequestModel>(CuentaEntity);
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