using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningBook.Domain.Interfaces;

namespace PlanningBook.Themes.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class StripeCustomersController(
        IQueryExecutor _queryExecutor,
        ICommandExecutor _commandExecutor) : ControllerBase
    {

    }
}
