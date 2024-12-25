using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class AccountPersonLinkerConfiguration : BaseRelationDbEntityTypeConfiguration<AccountPersonLinker>
    {
        public override void Configure(EntityTypeBuilder<AccountPersonLinker> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => new { e.AccountId, e.PersonId });

            builder.HasOne(apl => apl.Account)
                .WithMany(a => a.AccountUserLinkers)
                .HasForeignKey(apl => apl.AccountId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
