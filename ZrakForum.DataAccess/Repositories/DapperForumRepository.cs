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
    public class DapperForumRepository : IForumRepository
    {
        private readonly DapperConnectionString connectionString;

        public DapperForumRepository(DapperConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Forum t)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Forum t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Forum>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var forums = await dbConnection.QueryAsync<Forum>("spForums_GetAll");
                return forums;
            }
        }

        public Forum GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Forum> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Forum GetByName(string name, bool includeThreads)
        {
            throw new NotImplementedException();
        }

        public async Task<Forum> GetByNameAsync(string name, bool includeThreads)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                if (includeThreads)
                {
                    var sql = @"SELECT f.*, t.*, a.* FROM
                                Forums f
                                INNER JOIN Threads t ON t.ForumId = f.Id
                                INNER JOIN Accounts a ON a.Id = t.AuthorId
                                WHERE f.Name = @Name";

                    var lookup = new Dictionary<int, Forum>();
                    var forum = (await dbConnection.QueryAsync<Forum, Thread, Account, Forum>(sql, (f, t, a) =>
                    {
                        Forum foru;
                        if (!lookup.TryGetValue(f.Id, out foru))
                        {
                            lookup.Add(f.Id, foru = f);
                        }

                        if (foru.Threads == null)
                        {
                            foru.Threads = new List<Thread>();
                        }

                        t.Author = a;
                        foru.Threads.Add(t);
                        return foru;
                    }, new { Name = name })).FirstOrDefault();

                    return forum;
                }
                else
                {
                    var forum = (await dbConnection.QueryAsync<Forum>("spForums_GetByName @Name", new { Name = name })).FirstOrDefault();
                    return forum;
                }
            }
        }
    }
}
