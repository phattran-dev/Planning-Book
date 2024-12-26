namespace PlanningBook.Domain.Interfaces
{
    public interface IDateAudited
    {
        DateTimeOffset? CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
    }
}
