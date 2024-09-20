using PlanningBook.Domain.Interfaces;

namespace PlanningBook.Users.Infrastructure.Entites
{
    public class User : IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
