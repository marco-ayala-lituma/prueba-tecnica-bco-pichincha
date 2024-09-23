using Microsoft.EntityFrameworkCore;
using Tercero.Infrastructure.contexts;

namespace Tercero.API.extensions.servers
{
  public class ServerExtension
  {
    public static void ConfigureSQLServices(WebApplicationBuilder builder)
    {
      builder.Services.AddDbContext<TerceroContext>(
        options =>
      {
        options.UseSqlServer(
          builder.Configuration.GetConnectionString(""));
       } 
        ); 
    }
  }
}
