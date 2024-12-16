using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class IdentityAccountClaimConfiguration : BaseRelationDbEntityTypeConfiguration<IdentityAccountClaim>
    {
        public override void Configure(EntityTypeBuilder<IdentityAccountClaim> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.UserId)
                .HasColumnName(nameof(IdentityAccountClaim.AccountId));
            builder.Ignore(r => r.AccountId);
        }
    }
}
