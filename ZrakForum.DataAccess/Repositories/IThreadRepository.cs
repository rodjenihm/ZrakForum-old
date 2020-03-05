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
        Thread GetByName(string name);
        Task<Thread> GetByNameAsync(string name);

        IEnumerable<Thread> GetByForumName(string forumName);
        Task<IEnumerable<Thread>> GetByForumNameAsync(string forumName);

        IEnumerable<ForumThread> GetForumThreadsByForumName(string forumName);
        Task<IEnumerable<ForumThread>> GetForumThreadsByForumNameAsync(string forumName);

    }
}
