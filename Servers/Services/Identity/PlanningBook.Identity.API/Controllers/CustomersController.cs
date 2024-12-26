using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Identity.Application.Domains.Customers.Commands;

namespace PlanningBook.Identity.API.Controllers
{
    [ApiController]
    [Route("identity")]
    public class CustomersController(
        IQueryExecutor _queryExecutor,
        ICommandExecutor _commandExecutor,
        HttpClient _httpClient
        ) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("SignUp")]
        public async Task<ActionResult<CommandResult<Guid>>> SignUpAsync([FromBody] SignUpCustomerCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
