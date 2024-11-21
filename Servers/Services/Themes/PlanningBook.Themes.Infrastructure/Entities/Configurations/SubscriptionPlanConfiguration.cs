using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Themes.Infrastructure.Entities.Configurations
{
    public class SubscriptionPlanConfiguration : BaseRelationDbEntityTypeConfiguration<SubscriptionPlan>
    {
        public override void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
        {
            base.Configure(builder);

            // Seed Data
            builder.HasData(
                new SubscriptionPlan { Id = new Guid("371cffea-2b1e-4c4d-aec8-cffd1ae43fef"), Description = "Basic", Name = "Basic", Price = 150 },
                new SubscriptionPlan { Id = new Guid("b677c4c6-669b-43ca-9897-83b5cb1c0cd9"), Description = "Elite", Name = "Elite", Price = 294 },
                new SubscriptionPlan { Id = new Guid("1fc13c2a-27e8-45cb-95dd-9dfd924db840"), Description = "Lifetime", Name = "Lifetime", Price = 710 });

        }
    }
}
