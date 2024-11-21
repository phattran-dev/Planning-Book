using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Themes.Infrastructure.Entities.Enums;

namespace PlanningBook.Themes.Infrastructure.Entities
{
    public class Order : EntityBase<Guid>, IDateAudited, IAuthorAudited<Guid>
    {
        public Guid ProductId { get; set; }
        public ProductType ProductType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
