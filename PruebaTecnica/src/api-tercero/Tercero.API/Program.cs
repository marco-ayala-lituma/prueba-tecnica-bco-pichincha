using Tercero.API.extensions.automappers;
using Tercero.API.extensions.injections;
using Tercero.API.extensions.servers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServerExtension.ConfigureSQLServices(builder);
DependencyInjectionExtension.ConfigureDependenciesInjectionsServices(builder);
AutoMapperExtension.ConfigureAutoMappersServices(builder.Services);
builder.Services.AddControllers();

// Configuración de logging
builder.Services.AddLogging(config =>
{
  config.AddConsole(); // Muestra logs en la consola
  config.AddDebug();   // Muestra logs en la salida de debug
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
