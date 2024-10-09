using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Infrastructure;
using PlanningBook.Themes.Infrastructure.Entities;
using System.Collections.Generic;

namespace PlanningBook.Themes.Application.Domain.Themes.Queries
{
    #region Query Model
    public sealed class GetThemesQuery : IQuery<QueryResult<List<Theme>>>
    {
        public PagingFilterCriteria PagingFilterCriteria { get; set; }

        public GetThemesQuery(PagingFilterCriteria pagingFilterCriteria)
        {
            PagingFilterCriteria = pagingFilterCriteria;
        }

        public ValidationResult GetValidationResult()
        {
            if (PagingFilterCriteria.PageIndex < 0 || PagingFilterCriteria.NumberItemsPerPage < 0)
                return ValidationResult.Failure();

            return ValidationResult.Success();
        }
    }
    #endregion Query Model

    #region Query Handler
    public sealed class GetThemesQueryHandler(
        IEFRepository<PBThemeDbContext, Theme, Guid> _themeRepository) : IQueryHandler<GetThemesQuery, QueryResult<List<Theme>>>
    {
        public async Task<QueryResult<List<Theme>>> HandleAsync(GetThemesQuery query, CancellationToken cancellationToken = default)
        {
            if (query == null || !query.GetValidationResult().IsValid)
                return QueryResult<List<Theme>>.Failure();

            var result = await _themeRepository.GetListAsync(
                null,
                query.PagingFilterCriteria.PageIndex,
                query.PagingFilterCriteria.NumberItemsPerPage,
                null,
                cancellationToken);


            return QueryResult<List<Theme>>.Success(result.ToList());
        }
    }
    #endregion Query Handler
}
