using Amaris.Library.Infraestructure.Entities;
using Amaris.Library.Infraestructure.Repositories;

namespace Amaris.Library.DataAccess
{
    public class BooksRepository : BaseRepository<Book, int>, IBooksRepository
    {
        public BooksRepository(LibraryContext context) : base(context) { }
    }
}
