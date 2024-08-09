using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningBook.Identity.Infrastructure
{
    public static class Startup
    {
        public static void AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO-Improve: Use DBEngine in BuildingBlock for add db connection
            //services.AddDbContext<MateWorkDbContext>(options => options.UseNpgsql(configuration["ConnectionStrings:ConnectionString"]));

            //services.AddScoped(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>));
            //services.AddScoped<IUnitOfWork<MateWorkDbContext>>(provider => new UnitOfWork<MateWorkDbContext>(provider));
        }
    }
}
