using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanningBook.DBEngine;

namespace PlanningBook.Identity.Infrastructure
{
    public class PBIdentityDbContext : IdentityDbContext
    {
        public PBIdentityDbContext(DbContextOptions<PBIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(BaseRelationDbEntityTypeConfiguration<>).Assembly);
        }
    }
}
