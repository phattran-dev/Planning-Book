namespace Planning_book.Domain.Interfaces
{
    public interface IAuthorAudited<TPrimaryKey>
    {
        public TPrimaryKey CreatedById { get; set; }
        public TPrimaryKey UpdatedById { get; set; }
    }
}
