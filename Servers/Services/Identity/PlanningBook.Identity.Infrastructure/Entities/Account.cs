using Microsoft.AspNetCore.Identity;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Identity.Infrastructure.Enums;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class Account : IdentityUser<Guid>, IEntityBase<Guid>, IFullAudited<Guid?>
    {
        public AccountStatus Status { get; set; }
        public string? TimeZone { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        public ICollection<AccountPersonLinker> AccountUserLinkers { get; set; }
        //public ICollection<AccountRoleLinker> AccountRoleLinkers { get; set; }
        public ICollection<AccountPermissionLinker> AccountPermissionLinkers { get; set; }
    }
}
