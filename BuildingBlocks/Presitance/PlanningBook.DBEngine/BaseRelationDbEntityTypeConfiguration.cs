using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlanningBook.DBEngine
{
    public abstract class BaseRelationDbEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>, IBaseEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable($"{typeof(TEntity).Name}s");
        }
    }
}