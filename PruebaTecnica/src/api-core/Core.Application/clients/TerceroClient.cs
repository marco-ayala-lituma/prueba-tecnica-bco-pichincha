using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Application.clients
{
  public class TerceroClient
  {
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private new readonly ILogger<TerceroClient> _logger;
    public TerceroClient(ILogger<TerceroClient> logger, HttpClient httpClient,
        IConfiguration configuration)
    {
      _logger = logger;
      _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
      _configuration = configuration;
    }
    public models.tercero.ClienteResponseModel Enviar(int request)
    {
      var resultado = new models.tercero.ClienteResponseModel();
      try
      {

        var ruta = $"{_configuration.GetSection("Externos:Tercero").Value}/api/Cliente/ObtenerPorId?request={request}";
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = _httpClient.GetAsync(ruta).Result;
        if (!response.IsSuccessStatusCode)
        {
          var jsonResultado = response.Content.ReadAsStringAsync();
          var ex = new Exception(jsonResultado.ToString());
          _logger.LogError(ex, "MasterClient");
        }
        else
        {
          string jsonResultado = response.Content.ReadAsStringAsync().Result;
          resultado = JsonConvert.DeserializeObject<models.tercero.ClienteResponseModel>(jsonResultado);
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MasterClient");
      }
      return resultado;
    }

  }
}
