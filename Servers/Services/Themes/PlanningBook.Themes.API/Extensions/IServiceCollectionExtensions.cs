using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Application.Domain.Orders.Command;
using PlanningBook.Themes.Application.Domain.Orders.Command.Model;
using PlanningBook.Themes.Application.Domain.Orders.Queries;
using PlanningBook.Themes.Application.Domain.Orders.Queries.Models;
using PlanningBook.Themes.Application.Domain.SubscriptionPlans.Commands;
using PlanningBook.Themes.Application.Domain.SubscriptionPlans.Queries;
using PlanningBook.Themes.Application.Domain.Themes.Commands;
using PlanningBook.Themes.Application.Domain.Themes.Queries;
using PlanningBook.Themes.Infrastructure.Entities;

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
            // Theme
            services.AddScoped<ICommandHandler<CreateThemeCommand, CommandResult<Guid>>, CreateThemeCommandHandler>();

            // SubcriptionPlan
            services.AddScoped<ICommandHandler<CreateSubscriptionPlanCommand, CommandResult<Guid>>, CreateSubscriptionPlanCommandHandler>();

            // Order
            services.AddScoped<ICommandHandler<CreateOrderCommand, CommandResult<Guid>>, CreateOrderCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateOrderCommand, CommandResult<Guid>>, UpdateOrderCommandHandler>();
            services.AddScoped<ICommandHandler<CheckoutCommand, CommandResult<CheckoutResultModel>>, CheckoutCommandHandler>();
            #endregion Commands

            #region Queries
            // Theme
            services.AddScoped<IQueryHandler<GetThemesQuery, QueryResult<List<Theme>>>, GetThemesQueryHandler>();

            // Subscription
            services.AddScoped<IQueryHandler<GetSubscriptionPlansQuery, QueryResult<List<SubscriptionPlan>>>, GetSubscriptionPlansQueryHandler>();

            // Order
            services.AddScoped<IQueryHandler<GetUserOrdersQuery, QueryResult<List<UserOrderModel>>>, GetUserOrdersQueryHandler>();

            #endregion Queries
            return services;
        }
    }
}
