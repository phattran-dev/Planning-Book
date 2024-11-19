using PlanningBook.Domain;

namespace PlanningBook.Themes.Infrastructure.Entities
{
    public class UserPaymentMethod : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public string StripePaymentMethodId { get; set; }

    }
}
