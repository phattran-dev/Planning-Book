using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Application.Services;
using PlanningBook.Themes.Infrastructure;
using PlanningBook.Themes.Infrastructure.Entities;

namespace PlanningBook.Themes.Application.Domain.Orders.Command
{
    #region Command Model
    public class CheckoutPaymentCommand : ICommand<CommandResult<string>>
    {
        public string OriginUrl { get; set; }
        public Guid OrderId { get; set; }
        public CheckoutPaymentCommand(Guid orderId, string originUrl)
        {
            OrderId = orderId;
            OriginUrl = originUrl;
        }
        public ValidationResult GetValidationResult()
        {
            if (string.IsNullOrWhiteSpace(OriginUrl) || Guid.Empty == OrderId)
                return ValidationResult.Failure();

            return ValidationResult.Success();
        }
    }
    #endregion Command Model
    public class CheckoutPayment(IEFRepository<PBThemeDbContext, Order, Guid> _orderRepository,
        IEFRepository<PBThemeDbContext, OrderDetail, Guid> _orderDetailRepository,
        StripePaymentService _paymentService) : ICommandHandler<CheckoutPaymentCommand, CommandResult<string>>
    {
        public async Task<CommandResult<string>> HandleAsync(CheckoutPaymentCommand command, CancellationToken cancellationToken = default)
        {
            if (command == null || !command.GetValidationResult().IsValid)
                return CommandResult<string>.Failure();

            var orderExisted = await _orderRepository.GetFirstAsync(x => x.Id == command.OrderId, cancellationToken);
            if (orderExisted == null)
                return CommandResult<string>.Failure();

            try
            {
                var checkoutSession = await _paymentService.CheckoutAsync(command.OriginUrl, command.OrderId, orderExisted.TotalPrice);

                if (checkoutSession == null) 
                    return CommandResult<string>.Failure();


                return CommandResult<string>.Success(checkoutSession.Url);
            }
            catch (Exception ex) {
                return CommandResult<string>.Failure();
            }
           

        }
    }
}
