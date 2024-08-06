namespace Planning_book.Domain.Interfaces
{
    public interface ICommandExecutor
    {
        Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
    }
}
