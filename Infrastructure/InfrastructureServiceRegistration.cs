using Application.ContractRepo;
using Infrastructure.Database;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            var DataConnectionString = configuration.GetConnectionString("db");
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(DataConnectionString);
            });
            return services;
        }
    }

}
