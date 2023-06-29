using NonProfitLibrary.Common.Models;

namespace NonProfitLibrary.Api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? BookType { get; set; }
        public bool IsAvailable { get; set; }
        
        public int ? ReaderId { get; set; }
        public Reader Reader { get; set; } = null!;

        public int? OrderId { get; set; }
        public Order Order { get; set; } = null!;


        public Book() { }
        public Book(BookModel bookModel)
        {
            Id = bookModel.Id;
            Title = bookModel.Title;
            Author = bookModel.Author;
            Description = bookModel.Description;
            Genre = bookModel.Genre;
            BookType = bookModel.BookType;
            IsAvailable = bookModel.IsAvailable;
            ReaderId = bookModel.ReaderId;
            OrderId = bookModel.OrderId;
        }

        public BookModel ToDto()
        {
            return new BookModel
            {
                Id = this.Id,
                Title = this.Title,
                Author = this.Author,
                Description = this.Description,
                Genre = this.Genre,
                BookType = this.BookType,
                IsAvailable = this.IsAvailable,
                ReaderId = this.ReaderId,
                OrderId = this.OrderId,

            };
        }
    }
}
