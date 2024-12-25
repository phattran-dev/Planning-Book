namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class AccountPersonLinker
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public Guid PersonId { get; set; }
    }
}
