using Amaris.Library.Infraestructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amaris.Library.Infraestructure.Repositories
{
    public interface IBooksRepository : IBaseRepository<Book, int>
    {
        Task<IEnumerable<Book>> GetByTitleAsync(string title);
    }
}
