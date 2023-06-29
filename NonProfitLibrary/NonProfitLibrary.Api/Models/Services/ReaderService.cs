using Microsoft.EntityFrameworkCore;
using NonProfitLibrary.Api.Models.Abstractions;
using NonProfitLibrary.Common.Models;
using System.Linq;

namespace NonProfitLibrary.Api.Models.Services
{
    public class ReaderService : AbstractionService, ICommonService<ReaderModel>
    {
       private ApplicationContext _db;
        public ReaderService(ApplicationContext db)
        {
            _db = db;
        }

        public bool Create(ReaderModel model)
        {
            bool result = DoAction(delegate ()
            {
                Reader reader = new Reader(model);
                _db.Reader.Add(reader);
                _db.SaveChanges();
            });
            return result;
        }

        public bool Delete(int id)
        {
            bool result = DoAction(delegate ()
            {
                Reader reader = _db.Reader.FirstOrDefault(b => b.Id == id) ?? new Reader();
                _db.Reader.Remove(reader);
                _db.SaveChanges();
            });
            return result;
        }

        public bool Update(int id, ReaderModel model)
        {
            bool result = DoAction(delegate ()
            {
                Reader reader = _db.Reader.FirstOrDefault(r => r.Id == id) ?? new Reader();
                reader.FirstName = model.FirstName;
                reader.LastName = model.LastName;
                reader.Email = model.Email;
                reader.Phone = model.Phone;
                reader.Password = model.Password;
                reader.BirthDate = model.BirthDate;

                _db.Reader.Update(reader);
                _db.SaveChanges();
            });
            return result;
        }

        public IQueryable<CommonModel> GetAll()
        {
            return _db.Reader.Select(b => b.ToDto() as CommonModel);
        }



        public ReaderModel GetById(int id)
        {
            Reader reader = _db.Reader.Include(r => r.TakenBook).Include(r => r.OrderBook). FirstOrDefault(r => r.Id == id) ?? new Reader();
            
            ReaderModel readerModel = reader.ToDto() ?? new ReaderModel();
            if (readerModel != null)
            {
                readerModel.TakenBooksId = _db.Book.Where(b=> b.ReaderId ==  id).Select(b => b.Id).ToList();
                readerModel.OrderBooksId = _db.Order.Where(b=> b.ReaderId ==  id).Select(b => b.Id).ToList();
            }
            return readerModel;
        }

        public void AddBookAsTaken(int id, List<int> booksIds)
        {
            Reader reader = _db.Reader.FirstOrDefault(r => r.Id == id) ?? new Reader();
            foreach (int bookId in booksIds)
            {
                Book book = _db.Book.FirstOrDefault(b => b.Id == bookId) ?? new Book();
                if (reader.TakenBook.Contains(book) == false)
                {
                    reader.TakenBook.Add(book);
                }
            }
            _db.SaveChanges();
        }

        public void RemoveBookFromTaken(int id, List<int> booksIds)
        {
            Reader reader = _db.Reader.Include(r => r.TakenBook).FirstOrDefault(r => r.Id == id) ?? new Reader();
            foreach (int bookId in booksIds)
            {
                Book book = _db.Book.FirstOrDefault(b => b.Id == bookId) ?? new Book();
                if (reader.TakenBook.Contains(book))
                {
                    reader.TakenBook.Remove(book);
                }
            }
            _db.SaveChanges();
        }


       public void AddBookToOrder(int id, List<int> booksIds)
        {
            Order order = _db.Order.FirstOrDefault(r => r.Id == id) ?? new Order();
            foreach (int bookId in booksIds)
            {
                Book? book = _db.Book.FirstOrDefault(b => b.Id == bookId) ?? new Book();
                if (order.BookOnOrder.Contains(book) == false)
                {
                    order.BookOnOrder.Add(book);
                }
            }
            _db.SaveChanges();
        }

        public void RemoveBookFromOrder(int id, List<int> booksIds)
        {
            Order order = _db.Order.Include(r => r.BookOnOrder).FirstOrDefault(r => r.Id == id) ?? new Order();
            foreach (int bookId in booksIds)
            {
                Book book = _db.Book.FirstOrDefault(b => b.Id == bookId) ?? new Book();
                if (order.BookOnOrder.Contains(book))
                {
                    order.BookOnOrder.Remove(book);
                }
            }
            _db.SaveChanges();
        }
    }
}
