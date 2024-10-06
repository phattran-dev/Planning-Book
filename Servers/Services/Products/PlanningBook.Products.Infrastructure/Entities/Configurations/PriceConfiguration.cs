using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Products.Infrastructure.Entities.Configurations
{
    public class PriceConfiguration : BaseRelationDbEntityTypeConfiguration<Price>
    {
        public override void Configure(EntityTypeBuilder<Price> builder)
        {
            base.Configure(builder);
        }
    }
}
