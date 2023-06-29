using NonProfitLibrary.Common.Models;

namespace NonProfitLibrary.Api.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }
        public List<Book> BookOnOrder { get; set; } = new List<Book>();
        
        public int? ReaderId { get; set; }
        public Reader? Reader { get; set;}
        
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }

        public Order() { }
        public Order(OrderModel orderModel)
        {

            ReaderId = orderModel.ReaderId;
            CreationDate = orderModel.CreationDate;
            Status = orderModel.Status;
        }

        public OrderModel ToDto()
        {
            return new OrderModel
            {
                Id = this.Id,
                Status = this.Status, 
                ReaderId = this.ReaderId,
                CreationDate = this.CreationDate,    
            };
        }
    }
}
