using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZrakForum.DataAccess.Entities
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public Account Author { get; set; }

        public int ThreadId { get; set; }
        public Thread Thread { get; set; }
    }
}
