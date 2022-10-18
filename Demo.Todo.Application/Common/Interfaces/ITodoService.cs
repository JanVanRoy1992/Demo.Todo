using Demo.Todo.Application.Todo.Dtos;

namespace Demo.Todo.Application.Common.Interfaces
{
    public interface ITodoService
    {
        Task<TodoDto[]> GetTodosAsync(Domain.TodoStatus status);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createTodo"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="DateInThePastException"></exception>
        /// <returns></returns>
        Task<int> CreateTodoAsync(CreateTodoDto createTodo);
    }
}
