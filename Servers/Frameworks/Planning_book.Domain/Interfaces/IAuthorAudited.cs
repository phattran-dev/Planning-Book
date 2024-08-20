namespace PlanningBook.Domain.Interfaces
{
    public interface IAuthorAudited<TPrimaryKey>
    {
        TPrimaryKey? CreatedById { get; set; }
        TPrimaryKey? UpdatedById { get; set; }
    }
}
