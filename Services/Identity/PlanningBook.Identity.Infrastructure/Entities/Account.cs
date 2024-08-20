using Microsoft.AspNetCore.Identity;
using PlanningBook.Domain.Interfaces;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class Account : IdentityUser<Guid>, IEntityBase<Guid>, IFullAudited<Guid?>
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }
    }
}
