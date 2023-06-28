using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonProfitLibrary.Common.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public List<int>?  OrderBooksIds { get; set; }
        public int? CustomerId { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }

        public OrderModel()
        {
        }

        public OrderModel(int customerId, DateTime creationDate, 
            OrderStatus status, List<int>? orderBooksIds =null)
        {
            CustomerId = customerId;
            CreationDate = creationDate;
            Status = status;
            OrderBooksIds = orderBooksIds;
        }
    }
}
