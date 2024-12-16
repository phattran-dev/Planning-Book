using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class AccountPermissionLinkerConfiguration : BaseRelationDbEntityTypeConfiguration<AccountPermissionLinker>
    {
        public override void Configure(EntityTypeBuilder<AccountPermissionLinker> builder)
        {
            base.Configure(builder);
        }
    }
}
