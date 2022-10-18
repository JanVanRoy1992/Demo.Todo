namespace Demo.Todo.Application.Common.Interfaces
{
    public interface IQueryHandler<TIn, TResult>
    {
        Task<TResult> ExecuteQuery(TIn request, CancellationToken cancellationToken);
    }
}
