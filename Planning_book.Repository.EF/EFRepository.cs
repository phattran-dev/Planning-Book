using Microsoft.EntityFrameworkCore;
using Planning_book.Domain;
using Planning_book.Domain.Constant;
using Planning_book.Domain.Interfaces;
using System.Linq.Expressions;

namespace Planning_book.Repository.EF
{
    public class EFRepository<TDbContext, TEntity, TPrimaryKey> : IEFRepository<TDbContext, TEntity, TPrimaryKey>
        where TDbContext : DbContext
        where TEntity : EntityBase<TPrimaryKey>
    {
        protected readonly TDbContext _dbContext;
        public EFRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if(entity is IDateAudited)
            {
                ((IDateAudited)entity).CreatedDate = DateTime.UtcNow;
                ((IDateAudited)entity).UpdatedDate = DateTime.UtcNow;
            }

            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            if (entities.FirstOrDefault() is IDateAudited)
            {
                foreach (var entity in entities)
                {
                    ((IDateAudited)entity).CreatedDate = DateTime.UtcNow;
                    ((IDateAudited)entity).UpdatedDate = DateTime.UtcNow;
                }
            }

            await _dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            return entities;
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> whereCondition = null, CancellationToken cancellationToken = default)
        {
            if (whereCondition == null)
                return await _dbContext.Set<TEntity>().CountAsync(cancellationToken);
            
            return await _dbContext.Set<TEntity>().CountAsync(whereCondition, cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task DeleteRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> whereCondition, List<Tuple<string, SortDirection>> sortCriteria = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> whereCondition = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> whereCondition, int pageIndex = 0, int numberItemsPerPage = 0, List<Tuple<string, SortDirection>> sortCriteria = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangeAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
