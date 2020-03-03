using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Entities;
using ZrakForum.DataAccess.Models;

namespace ZrakForum.DataAccess.Repositories
{
    public interface IThreadRepository : IRepository<Thread>
    {
        IEnumerable<Thread> GetByForumName(string forumName);
        Task<IEnumerable<Thread>> GetByForumNameAsync(string forumName);
    }
}
