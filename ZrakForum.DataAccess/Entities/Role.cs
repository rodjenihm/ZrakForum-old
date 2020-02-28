namespace ZrakForum.DataAccess.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
    }

    public static class RoleType
    {
        public static string USER = "User";
        public static string ADMIN = "Admin";
    }
}
