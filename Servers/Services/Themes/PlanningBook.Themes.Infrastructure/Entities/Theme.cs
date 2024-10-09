using PlanningBook.Domain;

namespace PlanningBook.Themes.Infrastructure.Entities
{
    public class Theme : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
