namespace Planning_book.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync();
        //TODO: BulkSaveChange
    }
}
