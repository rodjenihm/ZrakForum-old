using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Entities;
using ZrakForum.DataAccess.Models;
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

        public Task AddAsync(Thread t)
        {
            throw new NotImplementedException();
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

        public IEnumerable<ForumThread> GetForumThreadViewModel(string forumName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ForumThread>> GetForumThreadViewModelAsync(string forumName)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var forumThreads = await dbConnection.QueryAsync<ForumThread>("spThreads_GetForumIndexViewModel @ForumName", new { ForumName = forumName });
                return forumThreads;
            }
        }
    }
}
