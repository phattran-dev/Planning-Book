using PlanningBook.Domain.Constant;
using System.Linq.Expressions;

namespace PlanningBook.Domain.Interfaces
{
    // Use for get data as Original Format
    public interface IRepository<TDbContext, TEntity, TPrimaryKey> : IUnitOfWork
        where TEntity : EntityBase<TPrimaryKey>
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> whereCondition, List<Tuple<string, SortDirection>> sortCriteria = null, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> whereCondition = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> whereCondition, int pageIndex = 0, int numberItemsPerPage = 0, List<Tuple<string, SortDirection>> sortCriteria = null, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> whereCondition = null, CancellationToken cancellationToken = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default);

        // TODO: BulkAdd, BulkUpdate, BulkDelete
    }

    // Use for get data as other model (Ex: ReadOnly Model, View Model, etc)
    public interface IRepository<TDbContext, TEntity, TPrimaryKey, TModel>
        where TEntity : EntityBase<TPrimaryKey>
        where TModel : class
    {
        Task<TModel> GetAsync(Expression<Func<TModel, bool>> whereCondition, List<Tuple<string, SortDirection>> sortCriteria = null, CancellationToken cancellationToken = default);
        Task<TModel> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
        Task<TModel> GetFirstAsync(Expression<Func<TModel, bool>> whereCondition = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<TModel>> GetListAsync(Expression<Func<TModel, bool>> whereCondition, int pageIndex = 0, int numberItemsPerPage = 0, List<Tuple<string, SortDirection>> sortCriteria = null, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TModel, bool>> whereCondition = null, CancellationToken cancellationToken = default);
        Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default);
        Task<IEnumerable<TModel>> AddRangeAsync(IEnumerable<TModel> models, CancellationToken cancellationToken = default);
        Task UpdateAsync(TModel model, CancellationToken cancellationToken = default);
        Task DeleteAsync(TModel model, CancellationToken cancellationToken = default);
        Task DeleteRangeAsync(List<TModel> models, CancellationToken cancellationToken = default);

        // TODO: BulkAdd, BulkUpdate, BulkDelete
    }
}
