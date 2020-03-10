using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Entities;
using ZrakForum.DataAccess.Utilities;

namespace ZrakForum.DataAccess.Repositories
{
    public class DapperRoleRepository : IRoleRepository
    {
        private readonly DapperConnectionString connectionString;

        public DapperRoleRepository(DapperConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Role t)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Role t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetRolesByUsername(string username)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var roles = dbConnection.Query<string>("spAccountRoles_GetByUsername @Username", new { Username = username });
                return roles;
            }
        }

        public async Task<IEnumerable<string>> GetRolesByUsernameAsync(string username)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var roles = await dbConnection.QueryAsync<string>("spAccountRoles_GetByUsername @Username", new { Username = username });
                return roles;
            }
        }
    }
}
