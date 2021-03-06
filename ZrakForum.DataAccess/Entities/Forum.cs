﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZrakForum.DataAccess.Entities
{
    public class Forum : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Thread> Threads { get; set; }
    }
}
