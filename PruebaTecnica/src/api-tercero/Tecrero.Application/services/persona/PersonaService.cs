﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public bool Eliminar(int PersonaId)
    {
      throw new NotImplementedException();
    }

    public PersonaRequestModel ObtenerPersona(int request)
    {
      try
      {
        PersonaRequestModel resultado= new PersonaRequestModel();
        PersonaEntity personaEntity = new PersonaEntity();
        IPersonaDomainRepository repository = _unitOfWork.GetPersonaRepository();
        personaEntity = repository.FirstOrDefaultSync(x=>x.Id.Equals(request));
                  
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
