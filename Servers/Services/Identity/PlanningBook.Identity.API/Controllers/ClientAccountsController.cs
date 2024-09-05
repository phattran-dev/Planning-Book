using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Identity.Application.Accounts.Commands;

namespace PlanningBook.Identity.API.Controllers
{
    [ApiController]
    [Route("idenity")]
    public class ClientAccountsController : ControllerBase
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public ClientAccountsController(
            IQueryExecutor queryExecutor,
            ICommandExecutor commandExecutor)
        {
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        public async Task<ActionResult<CommandResult<Guid>>> SignUp([FromBody] SignUpClientAccountCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);
            return Ok(result);
        }
    }
}
