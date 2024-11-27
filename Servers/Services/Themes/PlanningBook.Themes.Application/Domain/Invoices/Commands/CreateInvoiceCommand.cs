using PlanningBook.Domain.Interfaces;
using PlanningBook.Domain;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Infrastructure;
using PlanningBook.Themes.Infrastructure.Entities;
using PlanningBook.Themes.Application.Services;
using PlanningBook.Themes.Infrastructure.Entities.Enums;

namespace PlanningBook.Themes.Application.Domain.Invoices.Commands
{
    public sealed class CreateInvoiceCommand : ICommand<CommandResult<string>>
    {
        public string OriginUrl { get; set; }
        public Guid ProductId { get; set; }
        public Guid? UserId { get; set; }
        public decimal? Price { get; set; }
        public bool IsUseStripePrice { get; set; }
        public ValidationResult GetValidationResult()
        {
            return ValidationResult.Success();
        }
    }

    public class CreateInvoiceCommandHandler(
        IEFRepository<PBThemeDbContext, Invoice, Guid> _invoiceRepository,
        IEFRepository<PBThemeDbContext, Product, Guid> _productRepository,
        IEFRepository<PBThemeDbContext, CustomerStripe, Guid> _customerStripeRepository,
        StripePaymentService _stripePaymentService) : ICommandHandler<CreateInvoiceCommand, CommandResult<string>>
    {
        public async Task<CommandResult<string>> HandleAsync(CreateInvoiceCommand command, CancellationToken cancellationToken = default)
        {
            var userExisted = await _customerStripeRepository.GetFirstAsync(x => x.UserId == command.UserId, cancellationToken);
            if (userExisted == null)
                return CommandResult<string>.Failure("User Not Existed");

            var productExited = await _productRepository.GetFirstAsync(x => x.Id == command.ProductId, cancellationToken);
            if (productExited == null)
                return CommandResult<string>.Failure("Product Not Existed");

            var invoice = new Invoice()
            {
                UserId = userExisted.UserId,
                PaymentStatus = PaymentStatus.Pending,
                TotalAmount = productExited.Price,
                ActualyTotalAmout = productExited.Price,
                ProductId = productExited.Id,
                Notes = $"{DateTime.Now.ToString()} - {userExisted.StripeCustomerId}"
            };
            await _invoiceRepository.AddAsync(invoice, cancellationToken);
            await _invoiceRepository.SaveChangeAsync(cancellationToken);

            var actualyProductPrice = command.Price ?? productExited.Price;
            var urlCheckout = "";
            if (command.IsUseStripePrice)
                urlCheckout = await _stripePaymentService.CheckoutSessionAsync(command.OriginUrl, invoice.Id, productExited.ProductType, 0, productExited.StripePriceId);
            else
                urlCheckout = await _stripePaymentService.CheckoutSessionAsync(command.OriginUrl, invoice.Id, productExited.ProductType, actualyProductPrice);
            
            return CommandResult<string>.Success(urlCheckout);
        }
    }
}
