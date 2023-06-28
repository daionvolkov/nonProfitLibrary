using NonProfitLibrary.Common.Models;

namespace NonProfitLibrary.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Book> OrderBook { get; set; } = new List<Book>();
        public int? CustomerId { get; set; }
        public Reader? Сustomer { get; set;}
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }

        public Order() { }
        public Order(OrderModel orderModel)
        {

            CustomerId = orderModel.CustomerId;
            CreationDate = orderModel.CreationDate;
            Status = orderModel.Status;
        }

        public OrderModel ToDto()
        {
            return new OrderModel
            {
                Id = this.Id,
                Status = this.Status, 
                CustomerId = this.CustomerId,
                CreationDate = this.CreationDate,    
            };
        }
    }
}
