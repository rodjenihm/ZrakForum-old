using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Entities;

namespace ZrakForum.DataAccess.Repositories
{
    public interface IThreadRepository : IRepository<Thread>
    {
        Thread GetByName(string name, bool includePosts = false);
        Task<Thread> GetByNameAsync(string name, bool includePosts = false);

        IEnumerable<Thread> GetByForumName(string forumName);
        Task<IEnumerable<Thread>> GetByForumNameAsync(string forumName);

        int CountByForum(string forumName);
        Task<int> CountByForumAsync(string forumName);
    }
}
