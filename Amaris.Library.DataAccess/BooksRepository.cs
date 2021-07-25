using Amaris.Library.Infraestructure.Entities;
using Amaris.Library.Infraestructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Amaris.Library.DataAccess
{
    public class BooksRepository : BaseRepository<Book, int>, IBooksRepository
    {
        public BooksRepository(LibraryContext context) : base(context) { }

        public async Task<IEnumerable<Book>> GetByTitleAsync(string title)
        {
            return await _context.Books.Where(x => x.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }
    }
}
