using PlanningBook.Domain;
using PlanningBook.Themes.Infrastructure.Entities.Enums;

namespace PlanningBook.Themes.Infrastructure.Entities
{
    public class SubscriptionPlan : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public SubscriptionType Type { get; set; }
    }
}
