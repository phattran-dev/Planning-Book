using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Infrastructure;
using PlanningBook.Themes.Infrastructure.Entities;
using PlanningBook.Themes.Infrastructure.Entities.Enums;

namespace PlanningBook.Themes.Application.Domain.Orders.Command
{
    #region Command Model
    public sealed class CreateOrderCommand : ICommand<CommandResult<Guid>>
    {
        public ProductType ProductType { get; set; }
        public Guid ProductId { get; set; }
        public CreateOrderCommand(ProductType productType, Guid productId)
        {
            ProductType = productType;
            ProductId = productId;
        }

        public ValidationResult GetValidationResult()
        {
            if (ProductId == Guid.Empty)
                return ValidationResult.Failure();
            return ValidationResult.Success();
        }
    }
    #endregion Command Model

    #region Command Handler
    public class CreateOrderCommandHandler(
        IEFRepository<PBThemeDbContext, Order, Guid> _orderRepository,
        IEFRepository<PBThemeDbContext, Theme, Guid> _themeRepository,
        IEFRepository<PBThemeDbContext, SubscriptionPlan, Guid> _subcriptionPlanRepository) : ICommandHandler<CreateOrderCommand, CommandResult<Guid>>
    {
        public async Task<CommandResult<Guid>> HandleAsync(CreateOrderCommand command, CancellationToken cancellationToken = default)
        {
            if (command == null || !command.GetValidationResult().IsValid)
                return CommandResult<Guid>.Failure();

            try
            {
                Tuple<Guid, string, decimal> product = null;
                switch (command.ProductType)
                {
                    default:
                        product = null;
                        break;

                    case ProductType.Theme:
                        {
                            var theme = await _themeRepository.GetFirstAsync(x => x.Id == command.ProductId, cancellationToken);
                            product = new Tuple<Guid, string, decimal>(theme.Id, theme.Name, theme.Price);
                        }
                        break;

                    case ProductType.SubcriptionPlan:
                        {
                            var subcriptionPlan = await _subcriptionPlanRepository.GetFirstAsync(x => x.Id == command.ProductId, cancellationToken);
                            product = new Tuple<Guid, string, decimal>(subcriptionPlan.Id, subcriptionPlan.Name, subcriptionPlan.Price);
                        }
                        break;
                }

                if (product == null)
                    return CommandResult<Guid>.Failure();

                var order = new Order()
                {
                    ProductId = command.ProductId,
                    ProductType = command.ProductType,
                    PaymentStatus = PaymentStatus.Pending,
                    TotalPrice = product.Item3,
                    Note = product.Item2
                };

 
                await _orderRepository.AddAsync(order, cancellationToken);
 
                await _orderRepository.SaveChangeAsync(cancellationToken);

                return CommandResult<Guid>.Success(order.Id);
            }
            catch (Exception ex)
            {
                return CommandResult<Guid>.Failure();
            }

        }
    }
    #endregion Command Handler
}
