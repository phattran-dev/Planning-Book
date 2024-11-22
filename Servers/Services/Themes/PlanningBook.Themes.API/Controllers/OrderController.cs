using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Themes.Application.Domain.Orders.Command;
using PlanningBook.Themes.Application.Domain.SubscriptionPlans.Commands;

namespace PlanningBook.Themes.API.Controllers
{
    [EnableCors("AllowSpecificOrigins")]
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderController(
        IQueryExecutor _queryExecutor,
        ICommandExecutor _commandExecutor) : ControllerBase
    {
        [HttpPost("checkout")]
        public async Task<ActionResult<CommandResult<Guid>>> CreateAsync([FromBody] CheckoutCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
