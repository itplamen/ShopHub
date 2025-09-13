namespace ShopHub.Common
{
    public  static class ValidationConstants
    {
        public const int USERNAME_MIN_LENGTH = 3;

        public const int USERNAME_MAX_LENGTH = 20;

        public const string USERNAME_REGEX = "^[a-zA-Z0-9_]+$";

        public const int PASSWORD_MIN_LENGTH = 6;

        public const int PASSWORD_MAX_LENGTH = 100;

        public const string PASSWORD_REGEX = "^(?=.*[A-Z])(?=.*\\d).{6,}$";

        public const int FULL_NAME_MAX_LENGTH = 50; 
    }
}
