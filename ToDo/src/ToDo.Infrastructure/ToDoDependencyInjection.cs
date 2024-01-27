using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Abstractions;
using ToDo.Infrastructure.Persistance;

namespace ToDo.Infrastructure
{
    public static class ToDoDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IToDoApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"), options => 
                options.EnableRetryOnFailure());
            });

            return services;
        }
    }
}
