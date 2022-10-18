using Demo.Todo.Infrastructure;
using Demo.Todo.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Todo.Application.UnitTests
{
    public abstract class TestBase : IDisposable
    {
        public readonly ServiceProvider serviceProvider;

        public TestBase()
        {
            var services = new ServiceCollection();
            services.AddApplication();
            services.AddInfrastructure();

            serviceProvider = services.BuildServiceProvider();

            // Create BD & Seed BD
            var todoDbContext = GetScopedTodoDbContext();
            todoDbContext.Database.EnsureCreated();
            todoDbContext.Todos.AddRange(
                new Domain.Todo
                {
                    Id = 1,
                    Description = "Training software architecture",
                    DueDate = DateTime.Now.AddDays(1),
                    Status = Domain.TodoStatus.New
                },
                new Domain.Todo
                {
                    Id = 2,
                    Description = "Make presentation",
                    DueDate = DateTime.Now.AddDays(2),
                    Status = Domain.TodoStatus.New
                });
            todoDbContext.SaveChanges();
        }

        public void Dispose()
        {
            GetScopedTodoDbContext().Database.EnsureDeleted();
        }

        private TodoDbContext GetScopedTodoDbContext()
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            var scope = scopeFactory.CreateScope();
            return scope.ServiceProvider.GetService<TodoDbContext>();
        }
    }
}