using Microsoft.AspNetCore.Identity;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class IdentityAccountLogin : IdentityUserLogin<Guid>
    {
        public Guid AccountId { get; set; }
    }
}
