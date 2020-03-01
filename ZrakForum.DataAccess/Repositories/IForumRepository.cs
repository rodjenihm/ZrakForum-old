using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Entities;

namespace ZrakForum.DataAccess.Repositories
{
    public interface IForumRepository : IRepository<Forum>
    {
        Forum GetByName(string name);
        Task<Forum> GetByNameAsync(string name);
    }
}
