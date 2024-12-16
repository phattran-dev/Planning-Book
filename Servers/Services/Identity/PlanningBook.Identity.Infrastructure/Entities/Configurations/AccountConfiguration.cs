using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class AccountConfiguration : BaseRelationDbEntityTypeConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.HasData(new Account()
            {
                Id = new Guid("53f39533-b6d0-4f06-9d1e-74e8772c2631"),
                UserName = "Identity_System"
            });
        }
    }
}
