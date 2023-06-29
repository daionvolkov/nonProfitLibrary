using Microsoft.EntityFrameworkCore;
using NonProfitLibrary.Api.Models.Abstractions;
using NonProfitLibrary.Common.Models;

namespace NonProfitLibrary.Api.Models.Services
{
    public class OrderService : AbstractionService, ICommonService<OrderModel>  
    { 
      private ApplicationContext _db;

        public OrderService(ApplicationContext db)
        {
            _db = db;
        }

        public bool Create(OrderModel model)
        {
            bool result = DoAction(delegate ()
            {
                Order order = new Order(model);
                _db.Order.Add(order);
                _db.SaveChanges();
            });
            return result;
        }

        public bool Delete(int id)
        {
            bool result = DoAction(delegate ()
            {
                Order order = _db.Order.FirstOrDefault(o => o.Id == id) ?? new Order();
                _db.Order.Remove(order);
                _db.SaveChanges();
            });
            return result;
        }

        public bool Update(int id, OrderModel model)
        {
            bool result = DoAction(delegate ()
            {
                Order order = _db.Order.FirstOrDefault(b => b.Id == id) ?? new Order();
                order.Status = model.Status;
                _db.Order.Update(order);
                _db.SaveChanges();
            });
            return result;
        }

        public IQueryable<OrderModel> GetAll()
        {
            return _db.Order.Select(o => o.ToDto() as OrderModel);
        }

        public OrderModel GetById(int id)
        {
            Order order = _db.Order.FirstOrDefault(o => o.Id == id) ?? new Order();
            var orderModel = order.ToDto();
            return orderModel;
        }


        public void AddBookToOrder(int id, List<int> booksIds)
        {
            Order order = _db.Order.FirstOrDefault(o => o.Id == id) ?? new Order();
            foreach (int bookId in booksIds)
            {
                Book book = _db.Book.FirstOrDefault(b => b.Id == bookId) ?? new Book();
                if (order.BookOnOrder.Contains(book) == false)
                {
                    order.BookOnOrder.Add(book);
                }
            }
            _db.SaveChanges();
        }


        public void RemoveBookFromOrder(int id, List<int> booksIds)
        {
            Order order = _db.Order.Include(o => o.BookOnOrder).FirstOrDefault(o => o.Id == id) ?? new Order();
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
