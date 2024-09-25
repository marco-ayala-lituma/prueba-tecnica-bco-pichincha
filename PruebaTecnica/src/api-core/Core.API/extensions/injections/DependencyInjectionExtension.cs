using Core.Application.clients;
using Core.Application.services;
using Core.Application.services.cuenta;
using Core.Application.services.cuenta.interfaces;
using Core.Application.services.movimiento;
using Core.Application.services.movimiento.interfaces;
using Core.Domain.repositories.interfaces;
using Core.Domain.repositories.interfaces.generics;
using Core.Infrastructure.contexts;
using Core.Infrastructure.repositories.cuenta;
using Core.Infrastructure.repositories.generics;
using Core.Infrastructure.repositories.movimiento;

namespace Core.API.extensions.injections
{
  public class DependencyInjectionExtension
  {
    public static void ConfigureDependenciesInjectionsServices(WebApplicationBuilder builder)
    {
      builder.Services.AddScoped<CoreContext>();
      builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
      builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
      builder.Services.AddHttpClient();

      builder.Services.AddScoped<TerceroClient>();

      //Movimiento
      builder.Services.AddScoped<IMovimientoDomainRepository, MovimientoRepository>();
      builder.Services.AddScoped<IMovimientoService, MovimientoService>();

      //Cuenta
      builder.Services.AddScoped<ICuentaDomainRepository, CuentaRepository>();
      builder.Services.AddScoped<ICuentaService, CuentaService>();

    }
  }
}
