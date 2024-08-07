namespace PlanningBook.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync();
        //TODO: BulkSaveChange
    }
}
