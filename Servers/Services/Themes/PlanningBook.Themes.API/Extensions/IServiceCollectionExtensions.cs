using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Application.Domain.Invoices.Commands;
using PlanningBook.Themes.Application.Domain.Invoices.Queries;
using PlanningBook.Themes.Application.Domain.Invoices.Queries.Models;

namespace PlanningBook.Themes.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            #region Add Repositories
            services.AddScoped(typeof(IEFRepository<,,>), typeof(EFRepository<,,>));
            services.AddScoped(typeof(IEFRepository<,,,>), typeof(EFRepository<,,,>));
            services.AddScoped(typeof(IEFClassRepository<,,>), typeof(EFClassRepository<,,>));
            services.AddScoped(typeof(IEFClassRepository<,,,>), typeof(EFClassRepository<,,,>));
            #endregion Add Repositories

            return services;
        }

        public static IServiceCollection RegistryCommandQueryExecutor(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            return services;
        }

        public static IServiceCollection RegistryThemeModule(this IServiceCollection services, IConfiguration configuration)
        {
            #region Commands
            services.AddScoped<ICommandHandler<CreateInvoiceCommand, CommandResult<string>>, CreateInvoiceCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateInvoiceCommand, CommandResult<Guid>>, UpdateInvoiceCommandHandler>();
            #endregion Commands

            #region Queries
            services.AddScoped<IQueryHandler<GetUserInvoicesQuery, QueryResult<List<UserInvoiceModel>>>, GetUserInvoicesQueryHandler>();
            #endregion Queries
            return services;
        }
    }
}
