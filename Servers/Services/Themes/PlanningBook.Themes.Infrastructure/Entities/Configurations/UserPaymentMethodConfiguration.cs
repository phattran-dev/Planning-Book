using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Themes.Infrastructure.Entities.Configurations
{
    public class UserPaymentMethodConfiguration : BaseRelationDbEntityTypeConfiguration<UserPaymentMethod>
    {
        public override void Configure(EntityTypeBuilder<UserPaymentMethod> builder)
        {
            base.Configure(builder);
        }
    }
}
