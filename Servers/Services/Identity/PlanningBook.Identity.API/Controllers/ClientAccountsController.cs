﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Extensions;
using PlanningBook.Identity.Application.Accounts.Commands;
using PlanningBook.Identity.Application.ClientAccounts.Commands;
using PlanningBook.Identity.Application.ClientAccounts.Commands.CommandResults;

namespace PlanningBook.Identity.API.Controllers
{
    [ApiController]
    [Route("identity")]
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

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<ActionResult<CommandResult<SignInClientAccountCommandResult>>> SignIn([FromBody] SignInClientAccountCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("SignOut")]
        public async Task<ActionResult<CommandResult<bool>>> SignOut()
        {
            var command = new SignOutClientAccountCommand()
            {
                AccountId = User.GetCurrentAccountId(),
                Token = Request.GetCurrentJwtToken()
            };
            var result = await _commandExecutor.ExecuteAsync(command);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
