namespace PlanningBook.Domain
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<int>? ErrorCodes { get; set; }
        public List<string>? Messages { get; set; }

        public static ValidationResult Success()
        {
            return new ValidationResult() { IsValid = true };
        }

        public static ValidationResult Failure(List<int>? ErrorCodes = null, List<string>? Messages = null)
        {
            return new ValidationResult()
            {
                IsValid = false,
                ErrorCodes = ErrorCodes,
                Messages = Messages
            };
        }
    }
}
