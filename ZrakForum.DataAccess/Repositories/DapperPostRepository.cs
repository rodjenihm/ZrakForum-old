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

        public async Task AddAsync(Post post)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                await dbConnection.ExecuteAsync("spPosts_Create @Content, @AuthorId, @ThreadId", post);
            }
        }

        public int CountByForum(string forumName)
        {
            using (var dbConnection = new SqlConnection(connectionString.Value))
            {
                var sql = @"select 
                            count(p.Id)
                            from posts p
                            where p.ThreadId in (select
                                                 t.Id
                                                 from threads t
                                                 where t.ForumId = (select
                                                                    Id
                                                                    from forums f
                                                                    where f.Name = @ForumName))";

                return dbConnection.ExecuteScalar<int>(sql, new { ForumName = forumName });
            }
        }

        public Task<int> CountByForumAsync(string forumName)
        {
            throw new NotImplementedException();
        }

        public void Add(Post t)
        {
            throw new NotImplementedException();
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
