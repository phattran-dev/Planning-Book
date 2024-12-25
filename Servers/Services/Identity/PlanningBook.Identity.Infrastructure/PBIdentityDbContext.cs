using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanningBook.Identity.Infrastructure.Entities;
using System.Reflection;

namespace PlanningBook.Identity.Infrastructure
{
    //IdentityDbContext<Account, Role, Guid, IdentityAccountClaim, AccountRoleLinker, IdentityAccountLogin, IdentityRoleClaim<Guid>, IdentityAccountToken>
    public class PBIdentityDbContext : IdentityDbContext<Account, Role, Guid, IdentityAccountClaim, AccountRoleLinker, IdentityAccountLogin, IdentityAccountRoleClaim, IdentityAccountToken>
    {
        public PBIdentityDbContext(DbContextOptions<PBIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
