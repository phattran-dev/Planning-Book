using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningBook.Domain.Interfaces;

namespace PlanningBook.Themes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderController(
        IQueryExecutor _queryExecutor,
        ICommandExecutor _commandExecutor) : ControllerBase
    {

    }
}
