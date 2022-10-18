using Demo.Todo.Application.Common.Interfaces;
using Demo.Todo.Application.Todo.Dtos;
using Demo.Todo.Application.Todo.Queries.CreateTodos;
using Demo.Todo.Application.Todo.Queries.GetTodos;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Demo.Todo.Application.UnitTests.Todo
{
    public class TodoServiceTests : TestBase
    {
        [Fact]
        public async Task GetTodosAsync_Should_ReturnAllNewTodos()
        {
            var mediator = serviceProvider.GetService<IMediator>();

            var todos = await mediator.Send(new GetTodosQuery
            {
                Status = Domain.TodoStatus.New
            }, default);

            Assert.Equal(2, todos.Length);
        }

        [Fact]
        public async Task CreateTodoAsync_Should_ReturnNewId()
        {
            var dto = new CreateTodoDto
            {
                Description = "New Dto",
                DueDate = DateTime.Today.AddDays(2)
            };

            var mediator = serviceProvider.GetService<IMediator>();

            var result = await mediator.Send(new CreateTodosQuery { Description = dto.Description, DueDate = dto.DueDate }, default);

            Assert.Equal(3, result);
        }
    }
}
