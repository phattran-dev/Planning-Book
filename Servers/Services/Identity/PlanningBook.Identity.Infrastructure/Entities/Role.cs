using Microsoft.AspNetCore.Identity;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public ICollection<RolePermissionLinker> RolePermissionLinkers { get; set; }
    }
}
