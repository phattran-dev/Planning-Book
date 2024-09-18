using Microsoft.AspNetCore.Identity;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class AccountClaim : IdentityUserClaim<Guid>
    {
        public Guid AccountId { get; set; }
        //public virtual Account Account { get; set; }
    }
}
