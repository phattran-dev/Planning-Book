using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class RolePermissionLinkerConfiguration : BaseRelationDbEntityTypeConfiguration<RolePermissionLinker>
    {
        public override void Configure(EntityTypeBuilder<RolePermissionLinker> builder)
        {
            base.Configure(builder);
        }
    }
}
