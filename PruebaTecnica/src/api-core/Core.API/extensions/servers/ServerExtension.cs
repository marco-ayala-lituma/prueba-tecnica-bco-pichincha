using Core.Infrastructure.contexts;
using Microsoft.EntityFrameworkCore;

namespace Core.API.extensions.servers
{
  public class ServerExtension
  {
    public static void ConfigureSQLServices(WebApplicationBuilder builder)
    {
      builder.Services.AddDbContext<CoreContext>(
        options =>
        {
          options.UseSqlServer(
            builder.Configuration.GetConnectionString("CoreDb"));
        }
        );
    }
  }
}
