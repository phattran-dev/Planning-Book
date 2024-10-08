using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Themes.Infrastructure.Entities.Configurations
{
    public class SubscriptionPlanConfiguration : BaseRelationDbEntityTypeConfiguration<SubscriptionPlan>
    {
        public override void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
        {
            base.Configure(builder);
        }
    }
}
