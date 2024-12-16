using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class ApplicationConfiguration : BaseRelationDbEntityTypeConfiguration<Application>
    {
        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            base.Configure(builder);
        }
    }
}
