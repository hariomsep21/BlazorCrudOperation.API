
using DemoCRUD.Service.IServices;
using DemoCRUD.Service.Services;

namespace DealerApp.API.Middleware
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGenderService, GenderService>();

            services.AddScoped<IStateService, StateService>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          

            // Add other services here...

            return services;
        }
    }
}