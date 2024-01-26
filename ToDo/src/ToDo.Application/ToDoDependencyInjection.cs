using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ToDo.Application
{
    public static class ToDoDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
