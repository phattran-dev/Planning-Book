namespace Planning_book.Domain.Interfaces
{
    public interface IFullAudited<TPrimaryKey> : IDateAudited, IAuthorAudited<TPrimaryKey>
    {
    }
}
