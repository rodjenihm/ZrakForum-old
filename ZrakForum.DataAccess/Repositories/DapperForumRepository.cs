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
                    var forum = await GetForumWithThreadsAsync(name, dbConnection);
                    return forum;
                }
                else
                {
                    var forum = (await dbConnection.QueryAsync<Forum>("spForums_GetByName @Name", new { Name = name })).FirstOrDefault();
                    return forum;
                }
            }
        }

        // Helpers
        private static async Task<Forum> GetForumWithThreadsAsync(string name, SqlConnection dbConnection)
        {
            var sql = @"SELECT f.*, t.*, a.* FROM
                                Forums f
                                LEFT JOIN Threads t ON t.ForumId = f.Id
                                LEFT JOIN Accounts a ON a.Id = t.AuthorId
                                WHERE f.Name = @Name";

            var lookup = new Dictionary<int, Forum>();
            var forum = (await dbConnection.QueryAsync(sql, MapForumWithThreads(lookup), new { Name = name })).FirstOrDefault();
            return forum;
        }

        // After joining three tables (Forums, Threads and Accounts) we need to tell Dapper how to construct complex forum model
        private static Func<Forum, Thread, Account, Forum> MapForumWithThreads(Dictionary<int, Forum> lookup)
        {
            return (f, t, a) =>
            {
                Forum forum;
                if (!lookup.TryGetValue(f.Id, out forum))
                {
                    lookup.Add(f.Id, forum = f);
                }

                if (forum.Threads == null)
                {
                    forum.Threads = new List<Thread>();
                }

                if (t != null)
                {
                    t.Author = a;
                    forum.Threads.Add(t);
                }

                return forum;
            };
        }
    }
}
