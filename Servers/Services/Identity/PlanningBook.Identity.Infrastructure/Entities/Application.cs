using PlanningBook.Domain;

namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class Application : EntityBase<Guid>
    {
        public string Name { get; set; }
    }
}
