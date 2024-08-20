using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class AccountTokenConfiguration : BaseRelationDbEntityTypeConfiguration<AccountToken>
    {
        public override void Configure(EntityTypeBuilder<AccountToken> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.UserId)
                .HasColumnName(nameof(AccountToken.AccountId));
            builder.Ignore(p => p.AccountId);
        }
    }
}
