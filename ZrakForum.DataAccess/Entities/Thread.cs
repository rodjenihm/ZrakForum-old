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
        public int ForumId { get; set; }
    }
}
