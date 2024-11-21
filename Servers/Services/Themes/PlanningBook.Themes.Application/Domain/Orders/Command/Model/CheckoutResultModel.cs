namespace PlanningBook.Themes.Application.Domain.Orders.Command.Model
{
    public class CheckoutResultModel
    {
        public Guid OrderId { get; set; }
        public string UrlCheckout { get; set; }
    }
}
