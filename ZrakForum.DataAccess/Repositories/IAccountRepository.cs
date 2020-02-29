using System.Collections.Generic;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Entities;

namespace ZrakForum.DataAccess.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByUsername(string username);
        Task<Account> GetByUsernameAsync(string username);

        Account GetByEmail(string email);
        Task<Account> GetByEmailAsync(string email);

        IEnumerable<string> GetRolesByUsername(string username);
        Task<IEnumerable<string>> GetRolesByUsernameAsync(string username);
    }
}
