using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZrakForum.Web.Models
{
    public class ForumInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ThreadCount { get; set; }
        public int PostCount { get; set; }
    }
}