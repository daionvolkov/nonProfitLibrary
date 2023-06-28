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
    }
}
