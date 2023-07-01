using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonProfitLibrary.Api.Models.Abstractions;
using NonProfitLibrary.Common.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace NonProfitLibrary.Api.Models.Services
{
    public class BooksService : AbstractionService, ICommonService<BookModel>
    {
       private ApplicationContext _db;
        public BooksService(ApplicationContext db)
        {
            _db = db;
        }

        public bool Create(BookModel model)
        {
            bool result = DoAction(delegate ()
            {
                Book book = new Book(model);
                _db.Book.Add(book);
                _db.SaveChanges();
            });
            return result;
        }
       

        public bool CreateMultBooks(List<BookModel> bookModels)
        {
            return DoAction(delegate ()
            {
                var books = bookModels.Select(b => new Book(b));
                _db.AddRange(books);
                _db.SaveChanges();
            });
        }

        public bool Delete(int id)
        {
            bool result = DoAction(delegate ()
            {
                Book book = _db.Book.FirstOrDefault(b => b.Id == id) ?? new Book();
                _db.Book.Remove(book);
                _db.SaveChanges();
            });
            return result;
        }

        public bool Update(int id, BookModel model)
        {
            bool result = DoAction(delegate ()
            {
                Book book = _db.Book.FirstOrDefault(b => b.Id == id) ?? new Book();
                book.Title = model.Title;
                book.Author = model.Author;
                book.Description = model.Description;
                book.Genre = model.Genre;
                book.BookType = model.BookType;
                book.IsAvailable = model.IsAvailable;

                _db.Book.Update(book);
                _db.SaveChanges();
            });
            return result;
        }

        public bool UpdateIsAvailable(int id)
        {
            bool result = DoAction(delegate ()
            {
                Book book = _db.Book.FirstOrDefault(b => b.Id == id) ?? new Book();
                if (book.IsAvailable == true)
                {
                    book.IsAvailable = false;
                }
                else
                {
                    book.IsAvailable = true;
                }
                _db.Book.Update(book);
                _db.SaveChanges();
            });
            return result;
        }

        public IQueryable<BookModel> GetAll()
        {
            return _db.Book.Select(b => b.ToDto() as BookModel);
        }

        public BookModel GetById(int id)
        {
            Book book = _db.Book.FirstOrDefault(b => b.Id == id) ?? new Book();
            var bookModel = book.ToDto();
            return bookModel;
        }

        public IQueryable<BookModel> GetByTitle(string title)
        {
            return _db.Book.Where(b => b.Title.Contains(title)).Select(b => b.ToDto());
        }

        public IQueryable<BookModel> GetByAuthor(string author)
        {
            return _db.Book.Where(b => b.Author.Contains(author)).Select(b => b.ToDto());
        }

    }
}
