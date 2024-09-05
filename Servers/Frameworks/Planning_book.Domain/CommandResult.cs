namespace PlanningBook.Domain
{
    public class CommandResult<TData>
    {
        public TData? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }

        public static CommandResult<TData> Success(TData? data)
        {
            return new CommandResult<TData>()
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static CommandResult<TData> Failure(string? errorCode, string? errorMessages)
        {
            return new CommandResult<TData>()
            {
                IsSuccess = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessages
            };
        }
    }
}
