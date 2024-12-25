using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class RolePermissionLinkerConfiguration : BaseRelationDbEntityTypeConfiguration<RolePermissionLinker>
    {
        public override void Configure(EntityTypeBuilder<RolePermissionLinker> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => new { e.RoleId, e.PermissionId });

            builder.HasOne(rpl => rpl.Permission)
             .WithMany(a => a.RolePermissionLinkers)
             .HasForeignKey(rpl => rpl.PermissionId)
             .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
