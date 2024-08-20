using Microsoft.AspNetCore.Identity;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class AccountToken : IdentityUserToken<Guid>
    {
        public Guid AccountId { get; set; }
    }
}
