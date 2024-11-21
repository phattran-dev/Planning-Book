using PlanningBook.Domain;
using PlanningBook.Domain.Interfaces;
using PlanningBook.Repository.EF;
using PlanningBook.Themes.Application.Domain.Orders.Queries.Models;
using PlanningBook.Themes.Infrastructure;
using PlanningBook.Themes.Infrastructure.Entities;

namespace PlanningBook.Themes.Application.Domain.Orders.Queries
{
    #region Query Model
    public sealed class GetUserOrdersQuery : IQuery<QueryResult<List<UserOrderModel>>>
    {
        public Guid UserId { get; set; }
        public GetUserOrdersQuery(Guid userId)
        {
            UserId = userId;
        }

        public ValidationResult GetValidationResult()
        {
            if (UserId == Guid.Empty)
                return ValidationResult.Failure();
            return ValidationResult.Success();
        }
    }
    #endregion Query Model

    #region Query Handler
    public class GetUserOrdersQueryHandler(
        IEFRepository<PBThemeDbContext, Order, Guid> _orderRepository) : IQueryHandler<GetUserOrdersQuery, QueryResult<List<UserOrderModel>>>
    {
        public async Task<QueryResult<List<UserOrderModel>>> HandleAsync(GetUserOrdersQuery query, CancellationToken cancellationToken = default)
        {
            if (query == null || !query.GetValidationResult().IsValid)
                return QueryResult<List<UserOrderModel>>.Failure();

            try
            {
                var results = new List<UserOrderModel>();

                // TODO: Repository with including
                var orders = await _orderRepository.GetAsync(x => x.CreatedBy == query.UserId, null, cancellationToken);

                if (orders.Any())
                    results = orders.Select(x => new UserOrderModel
                    {
                        OrderId = x.Id,
                        PaymentStatus = x.PaymentStatus,
                        Price = x.TotalPrice,
                        ProductId = x.ProductId,
                        ProductType = x.ProductType
                    }).ToList();

                return QueryResult<List<UserOrderModel>>.Success(results);
            }
            catch (Exception ex)
            {
                return QueryResult<List<UserOrderModel>>.Failure();
            }
        }
    }
    #endregion Query Handler
}
