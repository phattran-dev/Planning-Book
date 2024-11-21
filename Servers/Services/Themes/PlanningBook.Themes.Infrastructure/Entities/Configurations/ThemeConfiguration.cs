using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Themes.Infrastructure.Entities.Configurations
{
    public class ThemeConfiguration : BaseRelationDbEntityTypeConfiguration<Theme>
    {
        public override void Configure(EntityTypeBuilder<Theme> builder)
        {
            base.Configure(builder);

            // Seed Data
            builder.HasData(
                new Theme { Id = new Guid("835bc37f-8891-48da-9f01-4bfcbf50ab13"), Description = "Black", Name = "Black", Price = 150 },
                new Theme { Id = new Guid("27784869-292e-47e8-be5f-311d7a4aaf14"), Description = "White", Name = "White", Price = 250 },
                new Theme { Id = new Guid("eea6122c-c5d8-40f1-a44a-766008241255"), Description = "Rain", Name = "Rain", Price = 400 });
        }
    }
}
