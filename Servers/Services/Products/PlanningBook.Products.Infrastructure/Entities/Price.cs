using PlanningBook.Domain;

namespace PlanningBook.Themes.Infrastructure.Entities
{
    public class Price : EntityBase<Guid>
    {
        public decimal Value { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
