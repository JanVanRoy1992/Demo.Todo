using Demo.Todo.Application.Common.Interfaces;
using Demo.Todo.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Todo.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlite(connection);
            });

            services.AddScoped<ITodoDbContext>(collection => collection.GetRequiredService<TodoDbContext>());

            return services;
        }
    }
}
