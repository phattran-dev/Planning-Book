using PlanningBook.Domain;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class Permission : EntityBase<Guid>
    {
        public string Name { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
