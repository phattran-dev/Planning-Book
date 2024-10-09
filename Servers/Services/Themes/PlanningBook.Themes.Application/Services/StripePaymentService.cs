using Microsoft.Extensions.Options;
using PlanningBook.Themes.Application.Models;
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

        public Session CreateCheckoutSession(string successUrl, string cancelUrl)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
            {
                "card",
            },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = 2000, // For example, $20.00 (this value is in cents)
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "T-shirt",
                        },
                    },
                    Quantity = 1,
                },
            },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return session;
        }

        public async Task<Session> Test(string origin)
        {
            //var origin = $"{Request.Scheme}://{Request.Host}";

            //StripeConfiguration.ApiKey = _stripeOptions.ApiKey;

            var stripeSessionService = new SessionService();

            var stripeCheckoutSession = await stripeSessionService
                .CreateAsync(new SessionCreateOptions
                {
                    Mode = "payment",
                    ClientReferenceId = Guid.NewGuid().ToString(),
                    SuccessUrl = $"{origin}/confirmation.html",
                    CancelUrl = $"{origin}/index.html",
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
                                    Name = "Test Product"
                                },
                                UnitAmountDecimal = 10 * 100
                            },
                            Quantity = 1
                        }
                    }
                });

            return stripeCheckoutSession;
        }
    }
}
