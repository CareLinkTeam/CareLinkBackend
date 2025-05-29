using Application.Interface;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
// using Application.Services;
// using Application.Interface;


namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            return services;
        }
    }

}