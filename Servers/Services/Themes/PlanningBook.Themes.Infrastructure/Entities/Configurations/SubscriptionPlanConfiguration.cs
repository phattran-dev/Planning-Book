using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Themes.Infrastructure.Entities.Configurations
{
    public class SubscriptionPlanConfiguration : BaseRelationDbEntityTypeConfiguration<SubscriptionPlanConfiguration>
    {
        public override void Configure(EntityTypeBuilder<SubscriptionPlanConfiguration> builder)
        {
            base.Configure(builder);
        }
    }
}
