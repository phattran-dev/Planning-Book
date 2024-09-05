namespace PlanningBook.Domain
{
    public class QueryResult<TData>
    {
        public TData? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }

        public static QueryResult<TData> Success(TData data)
        {
            return new QueryResult<TData>()
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static QueryResult<TData> Failure(string errorCode, string errorMessages)
        {
            return new QueryResult<TData>()
            {
                IsSuccess = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessages
            };
        }
    }
}
