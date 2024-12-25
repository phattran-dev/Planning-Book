using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.Contants;
using PlanningBook.DBEngine;
using PlanningBook.Identity.Infrastructure.Enums;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class AccountConfiguration : BaseRelationDbEntityTypeConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.HasData(new Account()
            {
                Id = new Guid(SystemSeed.IDENTITY_SYSTEM_ID),
                UserName = "Identity_System",
                Status = AccountStatus.Active
            });
        }
    }
}
