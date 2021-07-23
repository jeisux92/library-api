using Amaris.Library.Infraestructure.Entities;
using Amaris.Library.Infraestructure.Repositories;
using Amaris.Library.Infraestructure.Services;
using Amaris.Library.Infraestructure.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amaris.Library.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public Task<int> CreateBookAsync(CreateBookViewModel book)
        {
            var bookToCreate = _mapper.Map<Book>(book);
            bookToCreate.CreatedOn = DateTime.UtcNow;
            return _booksRepository.CreateAsync(bookToCreate);
        }

        public async Task<BookViewModel> GetBookByIdAsync(int id)
        {
            var book = await _booksRepository.GetByIdAsync(id);
            return _mapper.Map<BookViewModel>(book);
        }

        public async Task<IEnumerable<BookViewModel>> GetBooksAsync()
        {
            var books = await _booksRepository.GetAll();
            return _mapper.Map<IEnumerable<BookViewModel>>(books);

        }
    }
}
