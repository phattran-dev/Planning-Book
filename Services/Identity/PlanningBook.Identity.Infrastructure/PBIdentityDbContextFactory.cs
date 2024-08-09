using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PlanningBook.Identity.Infrastructure
{
    public class PBIdentityDbContextFactory : IDesignTimeDbContextFactory<PBIdentityDbContext>
    {
        public PBIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PBIdentityDbContext>();
            optionsBuilder.UseSqlServer(args[0]);
            return new PBIdentityDbContext(optionsBuilder.Options);
        }
    }
}
