using Microsoft.EntityFrameworkCore;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;

namespace PlanningBook.Repository.EF
{
    public interface IEFRepository<TDbContext, TEntity, TPrimaryKey> : IRepository<TDbContext, TEntity, TPrimaryKey>
        where TDbContext : DbContext
        where TEntity : EntityBase<TPrimaryKey>
    {
    }

    public interface IEFRepository<TDbContext, TEntity, TPrimaryKey, TModel> : IRepository<TDbContext, TEntity, TPrimaryKey, TModel>
        where TDbContext : DbContext
        where TEntity: EntityBase<TPrimaryKey>
        where TModel : class
    { 
    }
}
