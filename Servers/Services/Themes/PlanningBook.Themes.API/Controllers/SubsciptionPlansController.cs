using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Themes.Application.Domain.SubscriptionPlans.Commands;
using PlanningBook.Themes.Application.Domain.SubscriptionPlans.Queries;
using PlanningBook.Themes.Infrastructure.Entities;

namespace PlanningBook.Themes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SubsciptionPlansController(
        IQueryExecutor _queryExecutor,
        ICommandExecutor _commandExecutor) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<ActionResult<CommandResult<Guid>>> CreateAsync([FromBody] CreateSubscriptionPlanCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet()]
        public async Task<ActionResult<QueryResult<List<SubscriptionPlan>>>> GetAsync(PagingFilterCriteria pagingFilterCriteria)
        {
            var result = await _queryExecutor.ExecuteAsync(new GetSubscriptionPlansQuery(pagingFilterCriteria));

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
