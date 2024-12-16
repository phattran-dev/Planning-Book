using Microsoft.AspNetCore.Identity;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class IdentityAccountToken : IdentityUserToken<Guid>
    {
        public Guid AccountId { get; set; }
    }
}
