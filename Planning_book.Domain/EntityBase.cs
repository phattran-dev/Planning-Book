using Planning_book.Domain.Interfaces;

namespace Planning_book.Domain
{
    public abstract class EntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
