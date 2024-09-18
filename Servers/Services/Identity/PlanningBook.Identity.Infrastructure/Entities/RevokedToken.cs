using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class RevokedToken : EntityBase<string>, IFullAudited<Guid>
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        Guid IAuthorAudited<Guid>.CreatedBy { get; set; }
        Guid IAuthorAudited<Guid>.UpdatedBy { get; set; }
    }
}
