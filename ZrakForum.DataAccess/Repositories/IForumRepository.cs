using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Entities;
using ZrakForum.DataAccess.Models;

namespace ZrakForum.DataAccess.Repositories
{
    public interface IForumRepository : IRepository<Forum>
    {
        Forum GetByName(string name);
        Task<Forum> GetByNameAsync(string name);

        IEnumerable<ForumThread> GetForumDetailsViewModel(string forumName);
        Task<IEnumerable<ForumThread>> GetForumDetailsViewModelAsync(string forumName);
    }
}
