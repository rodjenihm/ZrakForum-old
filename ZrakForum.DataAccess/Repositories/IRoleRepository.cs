using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Entities;

namespace ZrakForum.DataAccess.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<string> GetRolesByUsername(string username);
        Task<IEnumerable<string>> GetRolesByUsernameAsync(string username);
    }
}
