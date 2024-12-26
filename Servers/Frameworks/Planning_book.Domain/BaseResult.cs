namespace PlanningBook.Domain
{
    public class BaseResult<TData>
    {
        public TData? Data { get; set; }
        public bool IsSuccess { get; set; }
        public List<int>? ErrorCodes { get; set; }
        public List<string>? ErrorMessages { get; set; }

        public static CommandResult<TData> Success(TData? data)
        {
            return new CommandResult<TData>()
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static CommandResult<TData> Failure(List<int>? errorCodes = null, List<string>? errorMessages = null)
        {
            return new CommandResult<TData>()
            {
                IsSuccess = false,
                ErrorCodes = errorCodes,
                ErrorMessages = errorMessages
            };
        }

        public static CommandResult<TData> Failure(int errorCode, string? errorMessage = null)
        {
            return new CommandResult<TData>()
            {
                IsSuccess = false,
                ErrorCodes = new List<int>() { errorCode },
                ErrorMessages = !string.IsNullOrWhiteSpace(errorMessage) ? new List<string>() { errorMessage } : null
            };
        }
    }
}
