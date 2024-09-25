using AutoMapper;
using Core.Application.clients;
using Core.Application.models.cuenta;
using Core.Application.models.movimiento;
using Core.Application.services.cuenta;
using Core.Application.services.cuenta.interfaces;
using Core.Application.services.movimiento.interfaces;
using Core.Domain.entities;
using Core.Domain.repositories.interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Application.services.movimiento
{
  public class MovimientoService : IMovimientoService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<MovimientoService> _logger;
    private readonly ICuentaService _cuentaService;
    private readonly TerceroClient _terceroClient;
    public MovimientoService(IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<MovimientoService> logger,
        ICuentaService cuentaService,
        TerceroClient terceroClient)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _logger = logger;
      _cuentaService = cuentaService;
      _terceroClient = terceroClient;
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
        _unitOfWork.BeginTransaction();

        IMovimientoDomainRepository repository = _unitOfWork.GetMovimientoRepository();
        MovimientoEntity MovimientoEntity = new MovimientoEntity();


        if (request.Valor == 0)
          throw new Exception("El valor es cero");


        var cuenta = _cuentaService.ObtenerCuenta(request.NumeroCuenta);
        if (request == null)
          throw new Exception("Client no existe");

        var movimientos = repository.GetAllWhere(x => x.NumeroCuenta.Equals(request.NumeroCuenta)).Result;
        if (!movimientos.Any())
        {
          //movimiento inicial
          MovimientoEntity movimientoInicial = new MovimientoEntity();
          _mapper.Map(request, movimientoInicial);
          movimientoInicial.Valor = cuenta.SaldoInicial;
          movimientoInicial.Saldo = cuenta.SaldoInicial;
          repository.AddSync(movimientoInicial);
          //agregamos el movimiento inicial
          movimientos.Add(movimientoInicial);
        }

        movimientos = movimientos.OrderBy(x => x.Id).ToList();
        var ultimoMovimiento = movimientos.Last();
        _mapper.Map(request, MovimientoEntity);
        if (request.TipoMovimiento.Equals("DEPOSITO"))
        {
          if (request.Valor < 0)
            throw new Exception("El valor debe ser positivo");
          MovimientoEntity.Saldo = ultimoMovimiento.Saldo + request.Valor;
        }
        else if (request.TipoMovimiento.Equals("RETIRO"))
        {
          if (request.Valor > 0)
            throw new Exception("El valor debe ser negativo");
          if (ultimoMovimiento.Saldo >= Math.Abs(request.Valor))
          {
            MovimientoEntity.Saldo = ultimoMovimiento.Saldo + request.Valor;
          }
          else
          {
            throw new Exception("Saldo no disponible");
          }
        }
        else
        {
          throw new Exception("Tipo de movimiento no permitido");
        }

        repository.AddSync(MovimientoEntity);
        _unitOfWork.SaveSync();

        _unitOfWork.CommitTransaction();
        return MovimientoEntity.Id;
      }
      catch
      {
        _unitOfWork.RollbackTransaction();
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

    public MovimientoReporteResponseModel ObtenerReporteMovimientos(ClienteReporteRequestModel request)
    {
      var report = new MovimientoReporteResponseModel();
      try
      {
        var cliente = _terceroClient.Enviar(request.ClienteId).Data;
        if (cliente.ClienteId == 0)
          throw new Exception("Client no existe");


        ICuentaDomainRepository repositoryCuentas = _unitOfWork.GetCuentaRepository();
        IMovimientoDomainRepository repositoryMovimientos = _unitOfWork.GetMovimientoRepository();

        report.Cliente = "test";

        var cuentas = repositoryCuentas.GetAllWhere(x => x.ClienteId.Equals(request.ClienteId)).Result;

        foreach (var itemCuenta in cuentas)
        {
          var movimientos = repositoryMovimientos.GetAllWhere(x => x.NumeroCuenta.Equals(itemCuenta.NumeroCuenta) && x.Fecha.Date.Equals(request.Fecha.Date)).Result;

          var movi = new List<MovimientosReporteRequestModel>();
          foreach (var itemMov in movimientos)
          {
            movi.Add(new MovimientosReporteRequestModel
            {
              Fecha = itemMov.Fecha,
              Saldo = itemMov.Saldo,
              TipoMovimiento = itemMov.TipoMovimiento,
              Valor = itemMov.Valor
            });
          }

          report.cuentas.Add(new CuentasReporteRequestModel
          {
            TipoCuenta = itemCuenta.TipoCuenta,
            SaldoInicial = itemCuenta.SaldoInicial,
            NumeroCuenta = itemCuenta.NumeroCuenta,
            Estado = itemCuenta.Estado,
            movimientos = movi
          });
        }
        return report;
      }
      catch
      {
        //salta al catch principal
        throw;
      }

    }
  }
}