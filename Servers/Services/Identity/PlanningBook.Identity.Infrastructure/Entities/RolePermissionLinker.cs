namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class RolePermissionLinker
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
