using Microsoft.Extensions.Options;
using PlanningBook.Themes.Application.Models;
using PlanningBook.Themes.Infrastructure.Entities;
using Stripe;
using Stripe.Checkout;

namespace PlanningBook.Themes.Application.Services
{
    public class StripePaymentService
    {
        public StripePaymentService(IOptions<StripeSettings> stripeSettings)
        {
            StripeConfiguration.ApiKey = stripeSettings.Value.SecretKey;
        }

        public async Task<Session> CheckoutAsync(string originUrl, Guid orderId, decimal price)
        {
            var stripeSessionService = new SessionService();

            var stripeCheckoutSession = await stripeSessionService.CreateAsync(new SessionCreateOptions
            {
                Mode = "payment",
                ClientReferenceId = Guid.NewGuid().ToString(),
                SuccessUrl = $"{originUrl}/confirmation?orderId={orderId}",
                CancelUrl = $"{originUrl}/cancel?orderId={orderId}",
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
