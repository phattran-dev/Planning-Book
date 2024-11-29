using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Extensions;
using PlanningBook.Themes.Application.Domain.Invoices.Commands;

namespace PlanningBook.Themes.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class InvoicesController(
        IQueryExecutor _queryExecutor,
        ICommandExecutor _commandExecutor) : ControllerBase
    {
        [HttpPost("checkout")]
        public async Task<ActionResult<CommandResult<Guid>>> CreateAsync([FromBody] CreateInvoiceCommand command)
        {
            var currentUserId = User.GetCurrentAccountId();
            command.UserId = currentUserId;

            var result = await _commandExecutor.ExecuteAsync(command);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
