using System;

namespace ZrakForum.DataAccess.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
