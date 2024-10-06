using PlanningBook.Domain;

namespace PlanningBook.Products.Infrastructure.Entities
{
    public class OrderDetail: EntityBase<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid PriceId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Price Price { get; set; }
    }
}
