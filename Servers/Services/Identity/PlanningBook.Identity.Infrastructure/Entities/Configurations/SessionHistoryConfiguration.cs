using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure.Entities.Configurations
{
    public class SessionHistoryConfiguration : BaseRelationDbEntityTypeConfiguration<SessionHistory>
    {
        public override void Configure(EntityTypeBuilder<SessionHistory> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => new { e.Token, e.AccountId });

            builder.HasOne(t => t.Account)
                .WithMany(a => a.SessionHistories)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Application)
                .WithMany(a => a.SessionHistories)
                .HasForeignKey(t => t.ApplicationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
