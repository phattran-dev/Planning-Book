namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class AccountUserLinker
    {
        public Guid AccountId { get; set; }
        public Guid UserId { get; set; }
    }
}
