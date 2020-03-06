using System.Collections.Generic;

namespace ZrakForum.DataAccess.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }

    public static class RoleType
    {
        public static string USER = "User";
        public static string ADMIN = "Admin";
    }
}
