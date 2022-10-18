using Demo.Todo.Application.Common.Exceptions;
using Demo.Todo.Application.Common.Interfaces;
using Demo.Todo.Application.Todo.Dtos;
using Demo.Todo.Domain;
using MediatR;

namespace Demo.Todo.Application.Todo.Queries.CreateTodos
{
    public class CreateTodosHandler : IRequestHandler<CreateTodosQuery, int>
    {
        private readonly ITodoDbContext dbContext;

        public CreateTodosHandler(ITodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(CreateTodosQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("Create todo dto should not be null!");

            if (string.IsNullOrWhiteSpace(request.Description))
                throw new ArgumentNullException("Description should not be null, empty or exist only of white spaces!");

            if (request.DueDate < DateTime.Now)
                throw new DateInThePastException($"Due date: {request.DueDate} should be in the future");

            var newTodo = new Domain.Todo
            {
                Description = request.Description,
                DueDate = request.DueDate,
                Status = TodoStatus.New
            };

            await dbContext.Todos.AddAsync(newTodo);
            await dbContext.SaveChangesAsync(default);

            return newTodo.Id;
        }
    }
}
