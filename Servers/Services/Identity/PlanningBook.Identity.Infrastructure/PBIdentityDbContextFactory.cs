using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PlanningBook.DBEngine.Constants;

namespace PlanningBook.Identity.Infrastructure
{
    public class PBIdentityDbContextFactory : IDesignTimeDbContextFactory<PBIdentityDbContext>
    {
        public PBIdentityDbContext CreateDbContext(string[] args)
        {
            // Load configuration
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .AddJsonFile("appsettings.Development.json", optional: true)
            //    .AddEnvironmentVariables()
            //    .Build();

            //// Use the same connection string key as in Startup.AddPBIdentityDbContext
            //var connectionString = args[0] ?? configuration[$"{DBEngineConstants.RootConnectionString}:Identity{DBEngineConstants.dbConnectionStringPrefix}"];

            var optionsBuilder = new DbContextOptionsBuilder<PBIdentityDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PlanningBookIdentity;User Id=sa;Password=ThienHoa0096@@;TrustServerCertificate=True;");
            return new PBIdentityDbContext(optionsBuilder.Options);
        }
    }
}
