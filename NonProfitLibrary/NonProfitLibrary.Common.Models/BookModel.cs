using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonProfitLibrary.Common.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? BookType { get; set; }
        public bool IsAvailable { get; set; }


        public int ? ReaderId { get; set; }
        public int? OrderId { get; set; }       

        public BookModel() { }


        public BookModel(string title, string author, 
            string description, string genre, string bookType, bool isAvailable, int? readerId, int? orderId)
        {
            Title = title;
            Author = author;
            Description = description;
            Genre = genre;
            BookType = bookType;
            IsAvailable = isAvailable;
            ReaderId = readerId;
            OrderId = orderId;
        }
    }

}
