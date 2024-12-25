using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class IdentityAccountRoleClaimConfiguration : BaseRelationDbEntityTypeConfiguration<IdentityAccountRoleClaim>
    {
        public override void Configure(EntityTypeBuilder<IdentityAccountRoleClaim> builder)
        {
            base.Configure(builder);
        }
    }
}
