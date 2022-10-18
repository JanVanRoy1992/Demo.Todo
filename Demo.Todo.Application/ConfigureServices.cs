using Demo.Todo.Application.Common.Interfaces;
using Demo.Todo.Application.Todo;
using Demo.Todo.Application.Todo.Dtos;
using Demo.Todo.Application.Todo.Queries.CreateTodos;
using Demo.Todo.Application.Todo.Queries.GetTodos;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Demo.Todo.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<IQueryHandler<CreateTodosQuery, int>, CreateTodosHandler>();

            //services.AddScoped<IQueryHandler<GetTodosQuery, TodoDto[]>, GetTodosHandlers>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
