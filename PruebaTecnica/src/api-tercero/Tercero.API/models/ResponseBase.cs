using Tercero.API.enums;

namespace Tercero.API.models
{
  public class ResponseBase
  {
    public ResponseCode Code { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
    public string? CodeText { get; set; }
  }
}