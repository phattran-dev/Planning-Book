using PlanningBook.Domain;

namespace PlanningBook.Products.Infrastructure.Entities
{
    public class Product : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
