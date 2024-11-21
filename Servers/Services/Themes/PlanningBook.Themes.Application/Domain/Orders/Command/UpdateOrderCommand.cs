using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Infrastructure;
using PlanningBook.Themes.Infrastructure.Entities;
using PlanningBook.Themes.Infrastructure.Entities.Enums;

namespace PlanningBook.Themes.Application.Domain.Orders.Command
{
    #region Command Model
    public sealed class UpdateOrderCommand : ICommand<CommandResult<Guid>>
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string PaymentInformation { get; set; }
        public UpdateOrderCommand(Guid userId, Guid orderId, PaymentStatus paymentStatus, string paymentInformation)
        {
            UserId = userId;
            OrderId = orderId;
            PaymentStatus = paymentStatus;
            PaymentInformation = paymentInformation;
        }

        public ValidationResult GetValidationResult()
        {
            if (UserId == Guid.Empty || OrderId == Guid.Empty || string.IsNullOrWhiteSpace(PaymentInformation))
                return ValidationResult.Failure();

            return ValidationResult.Success();
        }
    }
    #endregion Command Model

    #region Command Handler
    public class UpdateOrderCommandHandler(
        IEFClassRepository<PBThemeDbContext, Order, Guid> _orderRepository) : ICommandHandler<UpdateOrderCommand, CommandResult<Guid>>
    {
        public async Task<CommandResult<Guid>> HandleAsync(UpdateOrderCommand command, CancellationToken cancellationToken = default)
        {
            if (command == null || !command.GetValidationResult().IsValid)
                return CommandResult<Guid>.Failure();

            try
            {
                var orderExisted = await _orderRepository.GetByIdAsync(command.OrderId, cancellationToken);
                if (orderExisted == null)
                    return CommandResult<Guid>.Failure();

                orderExisted.Note = command.PaymentInformation;
                orderExisted.PaymentStatus = command.PaymentStatus;

                await _orderRepository.UpdateAsync(orderExisted, cancellationToken);
                await _orderRepository.SaveChangeAsync(cancellationToken);

                return CommandResult<Guid>.Success(orderExisted.Id);
            }
            catch (Exception ex)
            {
                return CommandResult<Guid>.Failure();
            }
        }
    }
    #endregion Command Handler
}
