using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Entities;
using ZrakForum.DataAccess.Utilities;

namespace ZrakForum.DataAccess.Repositories
{
    public class DapperAccountRepository : IAccountRepository
    {
        private readonly DapperConnectionString connectionString;

        public DapperAccountRepository(DapperConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Account account)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                dbConnection.Execute("spAccounts_Create @Email, @Username, @PasswordHash", account);
            }
        }

        public async Task AddAsync(Account account)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                await dbConnection.ExecuteAsync("spAccounts_Create @Email, @Username, @PasswordHash", account);
            }
        }

        public IEnumerable<Account> GetAll()
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var accounts = dbConnection.Query<Account>("spAccounts_GetAll");
                return accounts;
            }
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var accounts = await dbConnection.QueryAsync<Account>("spAccounts_GetAll");
                return accounts;
            }
        }

        public Account GetById(int id)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var account = dbConnection.Query<Account>("spAccounts_GetById @Id", new { Id = id }).FirstOrDefault();
                return account;
            }
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var account = (await dbConnection.QueryAsync<Account>("spAccounts_GetById @Id", new { Id = id })).FirstOrDefault();
                return account;
            }
        }

        public Account GetByUsername(string username)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var account = dbConnection.Query<Account>("spAccounts_GetByUsername @Username", new { Username = username }).FirstOrDefault();
                return account;
            }
        }

        public async Task<Account> GetByUsernameAsync(string username)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var account = (await dbConnection.QueryAsync<Account>("spAccounts_GetByUsername @Username", new { Username = username })).FirstOrDefault();
                return account;
            }
        }
    }
}
