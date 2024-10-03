using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.ServiceExtensions;
using kazakov_andrey_kt_43_21.Middlewares;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

/*
  Добавление, уд, реда
  Фильтрация по всем полям
*/

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
  // Add services to the container.

  builder.Logging.ClearProviders();
  builder.Host.UseNLog();

  builder.Services.AddControllers();
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();

  builder.Services.AddDbContext<TeacherDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
  );

  builder.Services.AddServices();

  var app = builder.Build();

  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }

  app.UseMiddleware<ExceptionHandlerMiddleware>();

  app.UseAuthorization();

  app.MapControllers();

  app.Run();

}
catch(Exception ex)
{
  logger.Error(ex, "Stopped program because of exception.");
}
finally
{
  LogManager.Shutdown();
}
