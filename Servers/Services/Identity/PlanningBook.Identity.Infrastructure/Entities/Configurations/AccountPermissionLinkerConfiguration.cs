using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class AccountPermissionLinkerConfiguration : BaseRelationDbEntityTypeConfiguration<AccountPermissionLinker>
    {
        public override void Configure(EntityTypeBuilder<AccountPermissionLinker> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => new { e.AccountId, e.PermissionId });

            builder.HasOne(apl => apl.Account)
                .WithMany(a => a.AccountPermissionLinkers)
                .HasForeignKey(apl => apl.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(apl => apl.Permission)
                .WithMany(a => a.AccountPermissionLinkers)
                .HasForeignKey(apl => apl.PermissionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
