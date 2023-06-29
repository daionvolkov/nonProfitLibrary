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
        public List<int>? BookOnOrderIds { get; set; }
        public int? ReaderId { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }

        public OrderModel()
        {
        }

        public OrderModel(int readerId, DateTime creationDate, 
            OrderStatus status, List<int>? bookOnOrderIds = null)
        {
            ReaderId = readerId;
            CreationDate = creationDate;
            Status = status;
            BookOnOrderIds = bookOnOrderIds;
        }
    }
}
