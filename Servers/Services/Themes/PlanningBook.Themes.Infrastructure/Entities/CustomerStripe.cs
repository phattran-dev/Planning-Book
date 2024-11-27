using PlanningBook.Domain;

namespace PlanningBook.Themes.Infrastructure.Entities
{
    public class CustomerStripe : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public string StripeCustomerId { get; set; }
        public string StripePaymentMethodId { get; set; }
    }
}
