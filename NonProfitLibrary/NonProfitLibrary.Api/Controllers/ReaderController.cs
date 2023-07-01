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
    public class ReaderController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly ReaderService _readerService;
        private readonly BooksService _booksService;

        public ReaderController(ApplicationContext db)
        {
            _db = db;
            _readerService = new ReaderService(db);
        }

        [HttpGet]
        public async Task<IEnumerable<CommonModel>> GetAllReaders()
        {
            return await _readerService.GetAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reader = _readerService.GetById(id);
            return reader==null ? NoContent() : Ok(reader);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ReaderModel readerModel)
        {
            if(readerModel != null)
            {
                var result = _readerService.Create(readerModel);
                return result ? Ok(result) : NoContent();
            }
            return BadRequest();
        }


        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] ReaderModel readerModel)
        {
            if (readerModel != null)
            {
                bool result = _readerService.Update(id, readerModel);
                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _readerService.Delete(id);
            return result ? Ok() : NotFound();
        }

        [HttpPatch("{id}/takenBooks")]
        public IActionResult AddTakenBooksToReader(int id, [FromBody] List<int> takenBooksId)
        {
            if(takenBooksId != null)
            {
                _readerService.AddBookAsTaken(id, takenBooksId);
               
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch("{id}/takenBooks/remove")]
        public IActionResult RemoveTakenBooksFromReader(int id, [FromBody] List<int> takenBooksId)
        {
            if (takenBooksId != null)
            {
                _readerService.RemoveBookFromTaken(id, takenBooksId);
                return Ok();
            }
            return BadRequest();    
        }

    }
}
