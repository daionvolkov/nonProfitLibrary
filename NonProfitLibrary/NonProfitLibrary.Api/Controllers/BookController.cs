using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonProfitLibrary.Api.Models;
using NonProfitLibrary.Api.Models.Services;
using NonProfitLibrary.Common.Models;

namespace NonProfitLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly BooksService _bookService;

        public BookController(ApplicationContext db)
        {
            _db = db;
            _bookService = new BooksService(db);
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("TEST TEST " + DateTime.Now);
        }


        [HttpGet]
        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            return await _bookService.GetAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id) 
        {
            var book = _bookService.GetById(id);
            return book==null ? NotFound() : Ok(book);
        }

        [HttpGet("{title}/title")]
        public IActionResult GetBookByTitle(string title)
        {
            var book = _bookService.GetByTitle(title);
            return book == null ? NotFound() : Ok(book);
        }


        [HttpGet("{author}/author")]
        public IActionResult GetBookByAuthor(string author)
        {
            var book = _bookService.GetByAuthor(author);
            return book == null ? NotFound() : Ok(book);
        }


        [HttpPost]
        public IActionResult Create([FromBody] BookModel bookModel)
        {
            if(bookModel != null) 
            {
                var result = _bookService.Create(bookModel);
                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }

        [HttpPost("all")]
        public async Task<IActionResult> CreateMultBooks([FromBody] List<BookModel> bookModel)
        {
            if (bookModel != null && bookModel.Count > 0)
            {
                bool result = _bookService.CreateMultBooks(bookModel);
                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] BookModel bookModel) 
        {
            if(bookModel != null)
            {
                bool result = _bookService.Update(id, bookModel);
                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            bool result = _bookService.Delete(id);
            return result ? Ok() : NotFound();
        }
        
    }
}
