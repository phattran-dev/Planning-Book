using PlanningBook.Domain;

namespace PlanningBook.Products.Infrastructure.Entities
{
    public class Price : EntityBase<Guid>
    {
        public decimal Value { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
