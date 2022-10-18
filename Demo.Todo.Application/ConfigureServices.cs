using Demo.Todo.Application.Common.Interfaces;
using Demo.Todo.Application.Todo;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Todo.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();

            return services;
        }
    }
}
