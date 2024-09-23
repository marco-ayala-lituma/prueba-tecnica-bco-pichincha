using Tecrero.Application.services;
using Tecrero.Application.services.persona.interfaces;
using Tecrero.Application.services.persona;
using Tercero.Domain.repositories.interfaces;
using Tercero.Domain.repositories.interfaces.generics;
using Tercero.Infrastructure.contexts;
using Tercero.Infrastructure.repositories.generics;
using Tercero.Infrastructure.repositories.persona;

namespace Tercero.API.extensions.injections
{
  public class DependencyInjectionExtension
  {
    public static void ConfigureDependenciesInjectionsServices(WebApplicationBuilder builder)
    {
      builder.Services.AddScoped<TerceroContext>();
      builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
      builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
      builder.Services.AddHttpClient();

      //Persona 
      builder.Services.AddScoped<IPersonaDomainRepository, PersonaRepository>();
      builder.Services.AddScoped<IPersonaService, PersonaService>();


    }
  }
}
