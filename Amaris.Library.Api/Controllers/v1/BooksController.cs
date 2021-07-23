using Amaris.Library.Infraestructure.Services;
using Amaris.Library.Infraestructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaris.Library.Api.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("{id}")]
        [ActionName("GetAsync")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _booksService.GetBookByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await _booksService.GetBooksAsync());


        [HttpPost()]
        public async Task<IActionResult> CreateAsync(CreateBookViewModel book)
        {
            int result = await _booksService.CreateBookAsync(book);
            if (result != 0)
            {
                return CreatedAtAction(nameof(GetAsync), new { id = result }, book);
            }
            return new StatusCodeResult(500);
        }
    }
}
