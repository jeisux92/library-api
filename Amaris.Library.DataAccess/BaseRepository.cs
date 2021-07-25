using Amaris.Library.Infraestructure.Entities;
using Amaris.Library.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amaris.Library.DataAccess
{
    public abstract class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : BaseEntity<TKey>
    {
        protected readonly LibraryContext _context;

        public BaseRepository(LibraryContext context)
        {
            _context = context;
        }

        public virtual async Task<int> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            T entity = await GetByIdAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(TKey id)
        {
            return await _context.FindAsync<T>(id);

        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
