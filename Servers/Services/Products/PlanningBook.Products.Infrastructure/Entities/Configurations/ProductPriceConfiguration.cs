using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Themes.Infrastructure.Entities.Configurations
{
    public class ProductPriceConfiguration : BaseRelationDbEntityTypeConfiguration<ProductPrice>
    {
        public override void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            base.Configure(builder);
        }
    }
}
