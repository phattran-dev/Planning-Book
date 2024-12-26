namespace PlanningBook.Identity.Application.Constants
{
    public class ErrorCodes
    {
        #region Customer's Errors
        public const int MISSING_COMMAND = 1000;
        public const int MISSING_REQUIRED_COMMAND_PROPERTY = 1001;
        public const int MISSING_COMMAND_PROPERTY_USERNAME = 1002;
        public const int MISSING_COMMAND_PROPERTY_PASSWORD = 1003;
        public const int MISSING_COMMAND_PROPERTY_EMAIL = 1004;
        public const int EXISTED_ACCOUNT = 1005;
        public const int DUPLICATE_EMAIL = 1006;
        public const int DUPLICATE_USERNAME = 1007;
        public const int DUPLICATE_PHONE_NUMBER = 1008;
        public const int CREATE_ACCOUNT_FAILED = 1009;
        #endregion Customer's Errors
    }
}
