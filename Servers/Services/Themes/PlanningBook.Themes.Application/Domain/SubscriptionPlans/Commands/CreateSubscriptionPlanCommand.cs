using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Infrastructure;
using PlanningBook.Themes.Infrastructure.Entities;
using PlanningBook.Themes.Infrastructure.Entities.Enums;

namespace PlanningBook.Themes.Application.Domain.SubscriptionPlans.Commands
{
    #region Command Model
    public sealed class CreateSubscriptionPlanCommand : ICommand<CommandResult<Guid>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public SubscriptionType Type { get; set; }

        public CreateSubscriptionPlanCommand(string name, string? description, SubscriptionType type)
        {
            Name = name;
            Description = description;
            Type = type;
        }

        public ValidationResult GetValidationResult()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return ValidationResult.Failure();

            return ValidationResult.Success();
        }
    }
    #endregion Command Model

    #region Command Handler
    public sealed class CreateSubscriptionPlanCommandHandler(
        IEFRepository<PBThemeDbContext, SubscriptionPlan, Guid> _subscriptionPlanRepository) : ICommandHandler<CreateSubscriptionPlanCommand, CommandResult<Guid>>
    {
        public async Task<CommandResult<Guid>> HandleAsync(CreateSubscriptionPlanCommand command, CancellationToken cancellationToken = default)
        {
            if (command == null || !command.GetValidationResult().IsValid)
                return CommandResult<Guid>.Failure();

            var product = new SubscriptionPlan()
            {
                Name = command.Name,
                Description = command?.Description,
                Type = command.Type
            };

            await _subscriptionPlanRepository.AddAsync(product);
            await _subscriptionPlanRepository.SaveChangeAsync();

            return CommandResult<Guid>.Success(product.Id);
        }
    }
    #endregion Command Handler
}
