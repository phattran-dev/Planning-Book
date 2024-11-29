using Microsoft.Extensions.Options;
using PlanningBook.Themes.Application.Models;
using PlanningBook.Themes.Infrastructure.Entities.Enums;
using Stripe;
using Stripe.Checkout;

namespace PlanningBook.Themes.Application.Services
{
    public class StripePaymentService
    {
        public StripePaymentService(IOptions<StripeSettings> stripeSettings)
        {
            //StripeConfiguration.ApiKey = stripeSettings.Value.SecretKey;
        }

        public async Task<string> CheckoutSessionAsync(string originUrl, Guid invoiceId, ProductType productType, decimal price, string? stripePriceId = null, string? stripeProductId = null)
        {
            var mode = productType == ProductType.SubcriptionPlan ? "subscription" : "payment";
            var successUrl = $"{originUrl}/planning-books/success?invoiceId={invoiceId}";
            var cancelUrl = $"{originUrl}/planning-books/cancel?invoiceId={invoiceId}";
            var lineItems = !string.IsNullOrWhiteSpace(stripePriceId) ?
                new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = stripePriceId,
                        Quantity = 1
                    }
                } :
                new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions()
                    {
                        PriceData = new SessionLineItemPriceDataOptions()
                        {
                            Currency = "USD",
                            ProductData = new SessionLineItemPriceDataProductDataOptions()
                            {
                                Name = Guid.NewGuid().ToString(),
                            },
                            UnitAmount = (long)price*100
                        },
                        Quantity = 1
                    }
                };

            var metadata = new Dictionary<string, string>();
            metadata["invoiceId"] = invoiceId.ToString();
            var checkoutSessionOptions = new SessionCreateOptions()
            {
                Mode = mode,
                ClientReferenceId = Guid.NewGuid().ToString(),
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
                CustomerEmail = "phattrandev@gmail.com",
                LineItems = lineItems,
                Metadata = metadata
            };

            var stripeSessionService = new SessionService();
            var stripeCheckoutSession = await stripeSessionService.CreateAsync(checkoutSessionOptions);

            return stripeCheckoutSession.Url;
        }

        public async Task<string> CreateCustomerAsync(Guid userId)
        {
            var customerService = new CustomerService();

            var options = new CustomerCreateOptions()
            {
                Name = userId.ToString(),
                Email = $"test{userId.ToString().Replace("-", "")}@mail.com"
            };

            var customer = await customerService.CreateAsync(options);
            if (customer != null)
                return customer.Id;

            return string.Empty;
        }

        public async Task<string> CreatePaymentMethodAsync(string byPassToken)
        {
            // By Pass Token Using for Demo only
            var options = new PaymentMethodCreateOptions();
            if (string.IsNullOrWhiteSpace(byPassToken))
            {
                // Demo show error cant not direcly send card/payment infor from our server to Stripe. Need use Stripe.js to implement this workflow
                options = new PaymentMethodCreateOptions()
                {
                    Type = "card",
                    Card = new PaymentMethodCardOptions()
                    {
                        Number = "4242424242424242",
                        ExpMonth = 12,
                        ExpYear = 28,
                        Cvc = "767"
                    }
                };
            }
            else
            {
                options = new PaymentMethodCreateOptions()
                {
                    Type = "card",
                    Card = new PaymentMethodCardOptions()
                    {
                        Token = byPassToken
                    }
                };
            }

            var paymentMethodService = new PaymentMethodService();
            var paymentMethod = await paymentMethodService.CreateAsync(options);

            return paymentMethod.Id;
        }

        public async Task AttachPaymentMethodAsync(string customerStripeId, string paymentMethodId)
        {
            var service = new PaymentMethodService();

            var options = new PaymentMethodAttachOptions()
            {
                Customer = customerStripeId
            };

            await service.AttachAsync(paymentMethodId, options);
        }

        public async Task DetachPaymentMethodAsync(string paymentMethodId)
        {
            var service = new PaymentMethodService();
            await service.DetachAsync(paymentMethodId);
        }

        public async Task<Session> CheckoutAsync(string originUrl, Guid orderId, decimal price)
        {
            var stripeSessionService = new SessionService();

            var stripeCheckoutSession = await stripeSessionService.CreateAsync(new SessionCreateOptions
            {
                Mode = "payment",
                ClientReferenceId = Guid.NewGuid().ToString(),
                SuccessUrl = $"{originUrl}/planning-books/confirmation?orderId={orderId}",
                CancelUrl = $"{originUrl}/planning-books/cancel?orderId={orderId}",
                CustomerEmail = "phattrandev@gmail.com",
                LineItems = new()
                    {
                        new()
                        {
                            PriceData = new()
                            {
                                Currency = "USD",
                                ProductData = new()
                                {
                                    Name = $"{orderId}"
                                },
                                UnitAmountDecimal = price
                            },
                            Quantity = 1
                        }
                    }
            });

            return stripeCheckoutSession;
        }
    }
}
