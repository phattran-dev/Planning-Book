using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;

namespace PlanningBook.Themes.Infrastructure.Entities
{
    public class Order : EntityBase<Guid>, IDateAudited, IAuthorAudited<Guid>
    {
        public string Note { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
 