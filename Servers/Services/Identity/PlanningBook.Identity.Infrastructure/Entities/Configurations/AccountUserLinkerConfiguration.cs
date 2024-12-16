using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class AccountUserLinkerConfiguration : BaseRelationDbEntityTypeConfiguration<AccountUserLinker>
    {
        public override void Configure(EntityTypeBuilder<AccountUserLinker> builder)
        {
            base.Configure(builder);
        }
    }
}
