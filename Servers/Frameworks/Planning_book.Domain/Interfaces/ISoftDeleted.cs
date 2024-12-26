namespace PlanningBook.Domain.Interfaces
{
    public interface ISoftDeleted
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
