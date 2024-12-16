using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class IdentityAccountLoginConfiguration : BaseRelationDbEntityTypeConfiguration<IdentityAccountLogin>
    {
        public override void Configure(EntityTypeBuilder<IdentityAccountLogin> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.UserId)
                .HasColumnName(nameof(IdentityAccountLogin.AccountId));
            builder.Ignore(r => r.AccountId);
        }
    }
}
