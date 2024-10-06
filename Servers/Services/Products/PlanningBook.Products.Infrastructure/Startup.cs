using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanningBook.DBEngine.Constants;

namespace PlanningBook.Products.Infrastructure
{
    public static class Startup
    {
        public static void AddPBProductDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO-Improve: Use DBEngine in BuildingBlock for add db connection
            var test = $"{DBEngineConstants.RootConnectionString}:Product{DBEngineConstants.dbConnectionStringPrefix}";
            services.AddDbContext<PBProductDbContext>(options => options.UseSqlServer(configuration[test]));
        }
    }
}
