using Demo.Todo.Application.Common.Interfaces;
using Demo.Todo.Application.Todo.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Todo.Application.Todo.Queries.GetTodos
{
    public class GetTodosHandlers : IRequestHandler<GetTodosQuery, TodoDto[]>
    {
        private readonly ITodoDbContext dbContext;

        public GetTodosHandlers(ITodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TodoDto[]> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Todos
                .Where(t => t.Status == request.Status)
                .Select(t => new TodoDto
                {
                    Id = t.Id,
                    Description = t.Description,
                    DueDate = t.DueDate
                }).ToArrayAsync();
        }
    }
}
