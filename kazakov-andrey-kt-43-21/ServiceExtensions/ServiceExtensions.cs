using kazakov_andrey_kt_43_21.Interfaces.DepartmentInterfaces;
using kazakov_andrey_kt_43_21.Interfaces.PositionInterfaces;
using kazakov_andrey_kt_43_21.Interfaces.StudentsInterfaces;

namespace kazakov_andrey_kt_43_21.ServiceExtensions
{
  public static class ServiceExtensions
  {
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
      services.AddScoped<ITeacherService, TeacherService>();
      services.AddScoped<IDepartmentService, DepartmentService>();
      services.AddScoped<IPositionService, PositionService>();

      return services;
    }
  }
}
