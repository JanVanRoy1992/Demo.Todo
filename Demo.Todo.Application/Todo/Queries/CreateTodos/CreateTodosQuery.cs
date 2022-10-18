using MediatR;

namespace Demo.Todo.Application.Todo.Queries.CreateTodos
{
    public class CreateTodosQuery : IRequest<int>
    {
        public string Description { get; set; } = default!;
        public DateTime DueDate { get; set; }
    }
}
