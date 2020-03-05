using System.Collections.Generic;

namespace ZrakForum.DataAccess.Entities
{
    public class Account : BaseEntity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
