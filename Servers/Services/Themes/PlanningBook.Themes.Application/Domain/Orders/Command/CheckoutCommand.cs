using PlanningBook.Domain.Interfaces;
using PlanningBook.Domain;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Application.Domain.Orders.Command.Model;
using PlanningBook.Themes.Application.Services;
using PlanningBook.Themes.Infrastructure;
using PlanningBook.Themes.Infrastructure.Entities;
using PlanningBook.Themes.Infrastructure.Entities.Enums;

namespace PlanningBook.Themes.Application.Domain.Orders.Command
{
    #region Command Model
    public sealed class CheckoutCommand : ICommand<CommandResult<CheckoutResultModel>>
    {
        public string OriginUrl { get; set; }
        public Guid ProductId { get; set; }
        public ProductType ProductType { get; set; }
        public CheckoutCommand(string originUrl)
        {
            OriginUrl = originUrl;
        }
        public ValidationResult GetValidationResult()
        {
            if (string.IsNullOrWhiteSpace(OriginUrl) || ProductId == Guid.Empty)
                return ValidationResult.Failure();

            return ValidationResult.Success();
        }
    }
    #endregion Command Model
    public class CheckoutCommandHandler(IEFRepository<PBThemeDbContext, Order, Guid> _orderRepository,
        IEFRepository<PBThemeDbContext, Theme, Guid> _themeRepository,
        IEFRepository<PBThemeDbContext, SubscriptionPlan, Guid> _subscriptionPlanRepository,
        StripePaymentService _paymentService) : ICommandHandler<CheckoutCommand, CommandResult<CheckoutResultModel>>
    {
        public async Task<CommandResult<CheckoutResultModel>> HandleAsync(CheckoutCommand command, CancellationToken cancellationToken = default)
        {
            if (command == null || !command.GetValidationResult().IsValid)
                return CommandResult<CheckoutResultModel>.Failure();

            try
            {
                Tuple<Guid, string, decimal> product = null;
                switch (command.ProductType)
                {
                    case ProductType.SubcriptionPlan:
                        {
                            var subscriptionPlan = await _subscriptionPlanRepository.GetByIdAsync(command.ProductId, cancellationToken);
                            if (subscriptionPlan != null)
                                product = new Tuple<Guid, string, decimal>(subscriptionPlan.Id, subscriptionPlan.Name, subscriptionPlan.Price);
                        }
                        break;

                    case ProductType.Theme:
                        {
                            var theme = await _themeRepository.GetByIdAsync(command.ProductId, cancellationToken);
                            if (theme != null)
                                product = new Tuple<Guid, string, decimal>(theme.Id, theme.Name, theme.Price);
                        }
                        break;
                }

                if(product == null)
                    return CommandResult<CheckoutResultModel>.Failure();

                var order = new Order()
                {
                    PaymentStatus = PaymentStatus.Pending,
                    ProductId = command.ProductId,
                    ProductType = command.ProductType,
                    TotalPrice = product.Item3,
                    Note = product.Item2
                };
                await _orderRepository.AddAsync(order, cancellationToken);
                await _orderRepository.SaveChangeAsync(cancellationToken);

                var checkoutSession = await _paymentService.CheckoutAsync(command.OriginUrl, order.Id, order.TotalPrice);

                if (checkoutSession == null)
                    return CommandResult<CheckoutResultModel>.Failure();

                var result = new CheckoutResultModel()
                {
                    OrderId = Guid.Empty,
                    UrlCheckout = checkoutSession.Url
                };

                return CommandResult<CheckoutResultModel>.Success(result);
            }
            catch (Exception ex)
            {
                return CommandResult<CheckoutResultModel>.Failure();
            }


        }
    }
}
