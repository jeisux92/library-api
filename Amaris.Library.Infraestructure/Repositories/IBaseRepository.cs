using Amaris.Library.Infraestructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amaris.Library.Infraestructure.Repositories
{
    public interface IBaseRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<int> CreateAsync(T entity);
        Task<T> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAll();
        Task UpdateAsync(T entity);
        Task DeleteAsync(TKey id);
    }
}
