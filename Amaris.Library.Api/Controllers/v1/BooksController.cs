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
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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

        [HttpGet()]
        public async Task<IActionResult> GetAsync([FromQuery] string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return Ok(await _booksService.GetBooksAsync());
            }
            var result = await _booksService.GetBookByTitleAsync(title);
            return result is null ? NotFound() : Ok(result);
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync() => Ok(await _booksService.GetBooksAsync());


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBookViewModel book)
        {
            int result = await _booksService.CreateBookAsync(book);
            if (result != 0)
            {
                return CreatedAtAction(nameof(GetAsync), new { id = result }, book);
            }
            return new StatusCodeResult(500);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateBookViewModel book)
        {
            await _booksService.UpdateBookAsync(id, book);
            return Ok();
        }
    }
}
