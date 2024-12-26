namespace PlanningBook.Identity.Infrastructure.Entities
{
    public class SessionHistory
    {
        public string Token { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
        public string RefreshToken { get; set; }
        public bool IsValid { get; set; }
        public DateTimeOffset ExpiredDate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }
        public string Metadata { get; set; }
        public string LoginProvider { get; set; }
    }
}
