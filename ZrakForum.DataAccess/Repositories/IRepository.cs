using System.Collections.Generic;
using System.Threading.Tasks;
using ZrakForum.DataAccess.Entities;

namespace ZrakForum.DataAccess.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        void Add(T t);
        Task AddAsync(T t);
    }
}
