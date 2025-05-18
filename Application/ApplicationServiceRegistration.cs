using Microsoft.Extensions.DependencyInjection;
// using Application.Services;
// using Application.Interface;


namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            // services.AddScoped<ITeacherService, TeacherService>();
            return services;
        }
    }

}