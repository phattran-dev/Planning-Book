using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;

namespace PlanningBook.Themes.Infrastructure.Entities
{
    public class ProductPrice : EntityBase<Guid>, IDateAudited
    {
        public Guid ProductId { get; set; }
        public Guid PriceId { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
