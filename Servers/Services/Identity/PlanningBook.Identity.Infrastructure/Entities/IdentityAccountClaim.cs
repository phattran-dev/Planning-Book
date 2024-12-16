using Microsoft.AspNetCore.Identity;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class IdentityAccountClaim : IdentityUserClaim<Guid>
    {
        public Guid AccountId { get; set; }
    }
}
