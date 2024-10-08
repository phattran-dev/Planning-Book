using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Themes.Infrastructure.Entities.Configurations
{
    public class ThemeConfiguration : BaseRelationDbEntityTypeConfiguration<Theme>
    {
        public override void Configure(EntityTypeBuilder<Theme> builder)
        {
            base.Configure(builder);
        }
    }
}
