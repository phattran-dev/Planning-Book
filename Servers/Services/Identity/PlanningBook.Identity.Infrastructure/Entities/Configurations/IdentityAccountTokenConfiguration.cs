using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class IdentityAccountTokenConfiguration : BaseRelationDbEntityTypeConfiguration<IdentityAccountToken>
    {
        public override void Configure(EntityTypeBuilder<IdentityAccountToken> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.UserId)
                .HasColumnName(nameof(IdentityAccountToken.AccountId));
            builder.Ignore(r => r.AccountId);
        }
    }
}
