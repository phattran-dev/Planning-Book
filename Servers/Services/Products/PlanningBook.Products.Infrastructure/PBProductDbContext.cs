using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PlanningBook.Products.Infrastructure
{
    public class PBProductDbContext : DbContext
    {
        public PBProductDbContext(DbContextOptions<PBProductDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
