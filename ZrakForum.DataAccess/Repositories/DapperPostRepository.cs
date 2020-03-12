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
    public class DapperPostRepository : IPostRepository
    {
        private readonly DapperConnectionString connectionString;

        public DapperPostRepository(DapperConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Post t)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Post post)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                await dbConnection.ExecuteAsync("spPosts_Create @Content, @AuthorId, @ThreadId", post);
            }
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
