using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercero.Domain.entities;
using Tercero.Domain.repositories.interfaces;
using Tecrero.Application.models.cliente;
using Tecrero.Application.services.cliente.interfaces;

namespace Tecrero.Application.services.cliente
{
  public class ClienteService : IClienteService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<ClienteService> _logger;

    public ClienteService(IUnitOfWork unitOfWork, IMapper mapper,
        ILogger<ClienteService> logger)
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
    public bool Actualizar(ClienteEditarRequestModel request)
    {
      try
      {
        ClienteEntity ClienteEntity = new ClienteEntity();

        IClienteDomainRepository repository = _unitOfWork.GetClienteRepository();
        _mapper.Map(request, ClienteEntity);
        repository.UpdateAsync(ClienteEntity);
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
    /// La creacion de Cliente es mediante un model request que obtiene solo los parameetros necesarios
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>

    public int Crear(ClienteCrearRequestModel request)
    {
      try
      {
        ClienteEntity ClienteEntity = new ClienteEntity();
        IClienteDomainRepository repository = _unitOfWork.GetClienteRepository();
        _mapper.Map(request, ClienteEntity);
        repository.AddSync(ClienteEntity);
        _unitOfWork.SaveSync();
        return ClienteEntity.Id;
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
        ClienteEntity ClienteEntity = new ClienteEntity();
        IClienteDomainRepository repository = _unitOfWork.GetClienteRepository();
        ClienteEntity = repository.FirstOrDefaultSync(x => x.Id.Equals(request));
        repository.RemoveAsync(ClienteEntity);
        _unitOfWork.SaveSync();
        return true;
      }
      catch
      {
        //salta al catch principal
        throw;
      }
    }

    public ClienteRequestModel ObtenerCliente(int request)
    {
      try
      {
        ClienteRequestModel resultado = new ClienteRequestModel();
        ClienteEntity ClienteEntity = new ClienteEntity();
        IClienteDomainRepository repository = _unitOfWork.GetClienteRepository();
        ClienteEntity = repository.FirstOrDefaultSync(x => x.Id.Equals(request));

        resultado = _mapper.Map<ClienteRequestModel>(ClienteEntity);
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
