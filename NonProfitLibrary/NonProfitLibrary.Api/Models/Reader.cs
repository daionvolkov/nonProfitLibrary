using NonProfitLibrary.Api.Models.Abstractions;
using NonProfitLibrary.Common.Models;

namespace NonProfitLibrary.Api.Models
{
    public class Reader : CommonObject
    {
        public int Id { get; set; }
        public List<Book> TakenBook { get; set; } = new List<Book>();
        public List<Book> OrderBook { get; set;} = new List<Book>();

        public Reader()
        {
        }

        public Reader(ReaderModel readerModel) : base(readerModel)
        {
            FirstName = readerModel.FirstName;
            LastName = readerModel.LastName;
            Email = readerModel.Email;
            Password = readerModel.Password;
            Phone = readerModel.Phone;
            BirthDate = readerModel.BirthDate;
            CreationDate = readerModel.CreationDate;
        }

        public ReaderModel ToDto()
        {
            return new ReaderModel
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                BirthDate = BirthDate,
                CreationDate = CreationDate,
            };
        }
    }
}
