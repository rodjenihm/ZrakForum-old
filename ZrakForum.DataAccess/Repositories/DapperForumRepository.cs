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

        public Forum GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Forum> GetByNameAsync(string name)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var forum = (await dbConnection.QueryAsync<Forum>("spForums_GetByName @Name", new { Name = name })).FirstOrDefault();
                return forum;
            }
        }

        public IEnumerable<ForumThread> GetForumDetailsViewModel(string forumName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ForumThread>> GetForumDetailsViewModelAsync(string forumName)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var forumThreads = await dbConnection.QueryAsync<ForumThread>("spThreads_GetForumDetailsViewModel @ForumName", new { ForumName = forumName });
                return forumThreads;
            }
        }
    }
}
