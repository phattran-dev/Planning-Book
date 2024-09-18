using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanningBook.DBEngine;
using PlanningBook.Identity.Infrastructure.Entities;
using PlanningBook.Identity.Infrastructure.Entities.Configurations;
using System.Reflection;

namespace PlanningBook.Identity.Infrastructure
{
    public class PBIdentityDbContext : IdentityDbContext<Account, Role, Guid, AccountClaim, AccountRole, AccountLogin, RoleClaim, AccountToken>
    {
        public PBIdentityDbContext(DbContextOptions<PBIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfiguration(new AccountConfiguration());
            //builder.ApplyConfiguration(new RoleConfiguration());
            //builder.ApplyConfiguration(new AccountClaimConfiguration());
            //builder.ApplyConfiguration(new AccountRoleConfiguration());
            //builder.ApplyConfiguration(new AccountLoginConfiguration());
            //builder.ApplyConfiguration(new RoleClaimConfiguration());
            //builder.ApplyConfiguration(new AccountTokenConfiguration());
            //builder.ApplyConfiguration(new RevokedTokenConfiguration());

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
