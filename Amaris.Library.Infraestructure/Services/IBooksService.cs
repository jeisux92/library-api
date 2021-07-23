using Amaris.Library.Infraestructure.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amaris.Library.Infraestructure.Services
{
    public interface IBooksService
    {
        Task<BookViewModel> GetBookByIdAsync(int id);
        Task<IEnumerable<BookViewModel>> GetBooksAsync();
        Task<int> CreateBookAsync(CreateBookViewModel book);
    }
}
