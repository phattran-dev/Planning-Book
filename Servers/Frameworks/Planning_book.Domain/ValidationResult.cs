namespace PlanningBook.Domain
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string>? ErrorCodes { get; set; }
        public List<string>? Messages { get; set; }
    }
}
