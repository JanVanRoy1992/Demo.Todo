namespace Demo.Todo.Application.Common.Interfaces
{
    public interface ICommandHandler<TIn>
    {
        Task Execute(TIn request, CancellationToken cancellationToken);
    }
}

