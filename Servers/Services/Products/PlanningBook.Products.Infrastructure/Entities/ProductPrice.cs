using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;

namespace PlanningBook.Products.Infrastructure.Entities
{
    public class ProductPrice : EntityBase<Guid>, IDateAudited
    {
        public Guid ProductId { get; set; }
        public Guid PriceId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Price Price { get; set; }
    }
}
