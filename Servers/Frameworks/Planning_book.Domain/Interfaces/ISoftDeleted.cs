namespace PlanningBook.Domain.Interfaces
{
    public interface ISoftDeleted<TAuthorKey>
    {
        public bool IsDeleted { get; set; }
        public TAuthorKey? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
