using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Themes.Application.Domain.Themes.Commands;
using PlanningBook.Themes.Application.Domain.Themes.Queries;
using PlanningBook.Themes.Infrastructure.Entities;

namespace PlanningBook.Themes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ThemesController(
        IQueryExecutor _queryExecutor,
        ICommandExecutor _commandExecutor) : ControllerBase
    {

        [HttpPost("Create")]
        public async Task<ActionResult<CommandResult<Guid>>> CreateAsync([FromBody] CreateThemeCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet()]
        public async Task<ActionResult<QueryResult<List<Theme>>>> GetAsync(PagingFilterCriteria pagingFilterCriteria)
        {
            var result = await _queryExecutor.ExecuteAsync(new GetThemesQuery(pagingFilterCriteria));

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
