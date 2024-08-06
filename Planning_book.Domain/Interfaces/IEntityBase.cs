namespace Planning_book.Domain.Interfaces
{
    public interface IEntityBase<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
