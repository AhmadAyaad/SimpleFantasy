namespace SimpleFantasy.Shared
{
    public class Authorization
    {
        public enum Roles
        {
            Admin,
            User
        }
        public const string DEFAULT_ADMIN_USERNAME = "admin";
        public const string DEFAULT_ADMIN_EMAIL = "admin@fantasy.com";
        public const string DEFAULT_ADMIN_PASSWORD = "Pa$$w0rd";
        public const Roles ADMIN_ROLE = Roles.Admin;
        public const Roles DEFAULT_ROLE = Roles.User;
    }
}
