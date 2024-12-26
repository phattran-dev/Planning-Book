using Microsoft.AspNetCore.Identity;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class AccountRoleLinker : IdentityUserRole<Guid>
    {
        public Guid AccountId { get; set; }
    }
}
