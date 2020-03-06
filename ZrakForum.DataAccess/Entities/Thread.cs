using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZrakForum.DataAccess.Entities
{
    public class Thread : BaseEntity
    {
        public string Name { get; set; }

        public int AuthorId { get; set; }
        public Account Author { get; set; }

        public int ForumId { get; set; }
        public Forum Forum { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
