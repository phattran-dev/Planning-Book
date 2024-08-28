using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Identity.Application.Commands.Accounts;

namespace PlanningBook.Identity.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegistryCommandQueryExecutor(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            return services;
        }

        public static IServiceCollection RegistryAccountModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICommandHandler<CreateAccountByUserNameCommand, Guid>, CreateAccountByUserNameCommandHandler>();

            return services;
        }
    }
}
