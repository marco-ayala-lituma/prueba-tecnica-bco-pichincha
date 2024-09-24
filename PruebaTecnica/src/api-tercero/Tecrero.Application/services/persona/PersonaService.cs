using AutoMapper;
using Microsoft.Extensions.Logging;
using Tecrero.Application.models.persona;
using Tecrero.Application.services.persona.interfaces;
using Tercero.Domain.entities;
using Tercero.Domain.repositories.interfaces;

namespace Tecrero.Application.services.persona
{
  public class PersonaService : IPersonaService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<PersonaService> _logger;

    public PersonaService(IUnitOfWork unitOfWork, IMapper mapper,
        ILogger<PersonaService> logger)
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
    public bool Actualizar(PersonaEditarRequestModel request)
    {
      try
      {
        PersonaEntity personaEntity = new PersonaEntity();

        IPersonaDomainRepository repository = _unitOfWork.GetPersonaRepository();
        _mapper.Map(request, personaEntity);
        repository.UpdateAsync(personaEntity);
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
    /// La creacion de persona es mediante un model request que obtiene solo los parameetros necesarios
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>

    public int Crear(PersonaCrearRequestModel request)
    {
      try
      {
        PersonaEntity personaEntity = new PersonaEntity();
        IPersonaDomainRepository repository = _unitOfWork.GetPersonaRepository();
        _mapper.Map(request, personaEntity);
        repository.AddSync(personaEntity);
        _unitOfWork.SaveSync();
        return personaEntity.Id;
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
        PersonaEntity personaEntity = new PersonaEntity();
        IPersonaDomainRepository repository = _unitOfWork.GetPersonaRepository();
        personaEntity = repository.FirstOrDefaultSync(x => x.Id.Equals(request));
        repository.RemoveAsync(personaEntity);
        _unitOfWork.SaveSync();
        return true;
      }
      catch
      {
        //salta al catch principal
        throw;
      }
    }

    public PersonaRequestModel ObtenerPersona(int request)
    {
      try
      {
        PersonaRequestModel resultado = new PersonaRequestModel();
        PersonaEntity personaEntity = new PersonaEntity();
        IPersonaDomainRepository repository = _unitOfWork.GetPersonaRepository();
        personaEntity = repository.FirstOrDefaultSync(x => x.Id.Equals(request));

        resultado = _mapper.Map<PersonaRequestModel>(personaEntity);
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
