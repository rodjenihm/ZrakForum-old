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
    public class DapperThreadRepository : IThreadRepository
    {
        private readonly DapperConnectionString connectionString;

        public DapperThreadRepository(DapperConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Thread t)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Thread thread)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                await dbConnection.ExecuteAsync("spThreads_Create @Name, @AuthorId, @ForumId", thread);
            }
        }

        public IEnumerable<Thread> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Thread>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Thread> GetByForumName(string forumName)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Thread>> GetByForumNameAsync(string forumName)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {

                var threads = await dbConnection.QueryAsync<Thread>("spThreads_GetByForumName @ForumName", new { ForumName = forumName });
                return threads;

            }
        }

        public Thread GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Thread> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Thread GetByName(string name, bool includePosts)
        {
            throw new NotImplementedException();
        }

        public async Task<Thread> GetByNameAsync(string name, bool includePosts)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                if (includePosts)
                {
                    var thread = await GetThreadWithPostsAsync(name, dbConnection);
                    return thread;
                }
                else
                {
                    var thread = (await dbConnection.QueryAsync<Thread>("spThreads_GetByName @Name", new { Name = name })).FirstOrDefault();
                    return thread;
                }
            }
        }

        public int CountByForum(string forumName)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var sql = @"select
                            count(t.Id)
                            from threads t
                            where ForumId = (select f.Id from forums f where Name = @ForumName);";

                return dbConnection.ExecuteScalar<int>(sql, new { ForumName = forumName });
            }
        }

        public Task<int> CountByForumAsync(string forumName)
        {
            throw new NotImplementedException();
        }

        // Helpers
        private static async Task<Thread> GetThreadWithPostsAsync(string name, SqlConnection dbConnection)
        {
            var sql = @"SELECT t.*, p.*, a.* FROM
                                Threads t
                                INNER JOIN Posts p ON p.ThreadId = t.Id
                                INNER JOIN Accounts a ON a.Id = p.AuthorId
                                WHERE t.Name = @Name";

            var lookup = new Dictionary<int, Thread>();
            var thread = (await dbConnection.QueryAsync(sql, MapThreadWithPostss(lookup), new { Name = name })).FirstOrDefault();
            return thread;
        }

        private static Func<Thread, Post, Account, Thread> MapThreadWithPostss(Dictionary<int, Thread> lookup)
        {
            return (t, p, a) =>
            {
                Thread thread;
                if (!lookup.TryGetValue(t.Id, out thread))
                {
                    lookup.Add(t.Id, thread = t);
                }

                if (thread.Posts == null)
                {
                    thread.Posts = new List<Post>();
                }

                p.Author = a;
                thread.Posts.Add(p);
                return thread;
            };
        }
    }
}
