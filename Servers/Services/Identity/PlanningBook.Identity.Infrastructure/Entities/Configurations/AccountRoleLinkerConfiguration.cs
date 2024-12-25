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

            builder.Property(r => r.RoleId)
                .HasColumnName("RoleId");
            builder.Ignore(r => r.RoleId);

            builder.HasKey(r => new { r.AccountId, r.RoleId });

            //builder.HasOne(e => e.Account)
            //    .WithMany()
            //    .HasForeignKey(e => e.AccountId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(e => e.Role)
            //    .WithMany()
            //    .HasForeignKey(e => e.RoleId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.Property(r => r.RoleId)
            //    .HasColumnName("RoleId");
            //builder.Ignore(r => r.RoleId);

            //builder.HasOne(arl => arl.Account)
            //    .WithMany(a => a.AccountRoleLinkers)
            //    .HasForeignKey(arl => arl.AccountId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.Role)
            //    .WithMany()
            //    .HasForeignKey(x => x.RoleId)
            //    .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
