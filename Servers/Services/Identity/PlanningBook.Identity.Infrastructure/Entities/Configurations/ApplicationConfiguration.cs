using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.Contants;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class ApplicationConfiguration : BaseRelationDbEntityTypeConfiguration<Application>
    {
        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            base.Configure(builder);

            builder.HasData(new Application()
            {
                Id = new Guid(SystemSeed.BO_WEB_APPLICATION_ID),
                Name = SystemSeed.BO_WEB_APPLICATION_Name
            },
            new Application()
            {
                Id = new Guid(SystemSeed.BO_MOBILE_APPLICATION_ID),
                Name = SystemSeed.BO_MOBILE_APPLICATION_Name
            },
            new Application()
            {
                Id = new Guid(SystemSeed.CLIENT_WEB_APPLICATION_ID),
                Name = SystemSeed.CLIENT_WEB_APPLICATION_Name
            },
            new Application()
            {
                Id = new Guid(SystemSeed.CLIENT_MOBILE_APPLICATION_ID),
                Name = SystemSeed.CLIENT_MOBILE_APPLICATION_Name
            });
        }
    }
}
