using Demo.Todo.Application.Common.Exceptions;
using Demo.Todo.Application.Common.Interfaces;
using Demo.Todo.Application.Todo.Dtos;
using Demo.Todo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.Todo.Application.Todo
{
    public class TodoService : ITodoService
    {
        private readonly ITodoDbContext dbContext;

        public TodoService(ITodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> CreateTodoAsync(CreateTodoDto createTodo)
        {
            if (createTodo == null)
                throw new ArgumentNullException("Create todo dto should not be null!");

            if (string.IsNullOrWhiteSpace(createTodo.Description))
                throw new ArgumentNullException("Description should not be null, empty or exist only of white spaces!");

            if (createTodo.DueDate < DateTime.Now)
                throw new DateInThePastException($"Due date: {createTodo.DueDate} should be in the future");

            var newTodo = new Domain.Todo
            {
                Description = createTodo.Description,
                DueDate = createTodo.DueDate,
                Status = TodoStatus.New
            };

            await dbContext.Todos.AddAsync(newTodo);
            await dbContext.SaveChangesAsync(default);

            return newTodo.Id;
        }

        public async Task<TodoDto[]> GetTodosAsync(TodoStatus status)
        {
            return await dbContext.Todos
                .Where(t => t.Status == status)
                .Select(t => new TodoDto
                {
                    Id = t.Id,
                    Description = t.Description,
                    DueDate = t.DueDate
                }).ToArrayAsync();
        }
    }
}
