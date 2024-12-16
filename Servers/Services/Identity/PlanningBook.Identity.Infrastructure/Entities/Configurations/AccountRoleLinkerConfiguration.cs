using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class AccountRoleLinkerConfiguration : BaseRelationDbEntityTypeConfiguration<AccountRoleLinker>
    {
        public override void Configure(EntityTypeBuilder<AccountRoleLinker> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.UserId)
                .HasColumnName(nameof(AccountRoleLinker.AccountId));
            builder.Ignore(r => r.AccountId);
        }
    }
}
