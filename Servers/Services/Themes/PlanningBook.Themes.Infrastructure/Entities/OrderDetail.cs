using PlanningBook.Domain;
using PlanningBook.Themes.Infrastructure.Entities.Enums;

namespace PlanningBook.Themes.Infrastructure.Entities
{
    public class OrderDetail : EntityBase<Guid>
    {
        public Guid EntityRelatedId { get; set; }
        public ProductType ProductType { get; set; }
        public Guid PriceId { get; set; }

        public virtual Price Price { get; set; }
    }
}
