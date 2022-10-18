using Demo.Todo.Application.Common.Interfaces;
using Demo.Todo.Application.Todo.Dtos;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Todo.Application.UnitTests.Todo
{
    public class TodoServiceTests : TestBase
    {
        [Fact]
        public async Task GetTodosAsync_Should_ReturnAllNewTodos()
        {
            var todoService = serviceProvider.GetService<ITodoService>();

            var todos = await todoService.GetTodosAsync(Domain.TodoStatus.New);

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

            var todoService = serviceProvider.GetService<ITodoService>();

            var result = await todoService.CreateTodoAsync(dto);

            Assert.Equal(3, result);
        }
    }
}
