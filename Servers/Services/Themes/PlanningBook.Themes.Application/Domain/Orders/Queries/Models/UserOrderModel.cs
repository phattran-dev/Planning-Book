using PlanningBook.Themes.Infrastructure.Entities.Enums;

namespace PlanningBook.Themes.Application.Domain.Orders.Queries.Models
{
    public sealed class UserOrderModel
    {
        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public Guid ProductId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
