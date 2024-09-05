using PlanningBook.Identity.Infrastructure.Entities;

namespace PlanningBook.Identity.Application.Providers
{
    public interface ITokenProvider
    {
        string GenerateToken(Account account);
    }
}
