using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Infrastructure;
using PlanningBook.Themes.Infrastructure.Entities;
using System.Collections.Generic;

namespace PlanningBook.Themes.Application.Domain.SubscriptionPlans.Queries
{
    #region Query Model
    public sealed class GetSubscriptionPlansQuery : IQuery<QueryResult<List<SubscriptionPlan>>>
    {
        public PagingFilterCriteria PagingFilterCriteria { get; set; }

        public GetSubscriptionPlansQuery(PagingFilterCriteria pagingFilterCriteria)
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
    public sealed class GetSubscriptionPlansQueryHandler(
        IEFRepository<PBThemeDbContext, SubscriptionPlan, Guid> _subscriptionPlanRepository) : IQueryHandler<GetSubscriptionPlansQuery, QueryResult<List<SubscriptionPlan>>>
    {
        public async Task<QueryResult<List<SubscriptionPlan>>> HandleAsync(GetSubscriptionPlansQuery query, CancellationToken cancellationToken = default)
        {
            if (query == null || !query.GetValidationResult().IsValid)
                return QueryResult<List<SubscriptionPlan>>.Failure();

            var result = await _subscriptionPlanRepository.GetListAsync(
                null,
                query.PagingFilterCriteria.PageIndex,
                query.PagingFilterCriteria.NumberItemsPerPage,
                null,
                cancellationToken);


            return QueryResult<List<SubscriptionPlan>>.Success(result.ToList());
        }
    }
    #endregion Query Handler
}
