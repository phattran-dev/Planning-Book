namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class AccountPermissionLinker
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
