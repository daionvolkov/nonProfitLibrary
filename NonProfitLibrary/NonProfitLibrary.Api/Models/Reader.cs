using NonProfitLibrary.Api.Models.Abstractions;
using NonProfitLibrary.Common.Models;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace NonProfitLibrary.Api.Models
{
    public class Reader : CommonObject
    {
        public int Id { get; set; }
        public List<Book> TakenBook { get; set; } = new List<Book>();
        public List<Order> OrderBook { get; set;} = new List<Order>();
   
        public Reader() {}

        public Reader(ReaderModel readerModel) : base(readerModel)
        {
            FirstName = readerModel.FirstName;
            LastName = readerModel.LastName;
            Email = readerModel.Email;
            Password = readerModel.Password;
            Phone = readerModel.Phone;
            BirthDate = readerModel.BirthDate;
            CreationDate = DateTime.Now;
           
        }

        public ReaderModel ToDto()
        {
            return new ReaderModel
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Password = this.Password,
                Email = this.Email,
                Phone = this.Phone,
                BirthDate = this.BirthDate,
                CreationDate = this.CreationDate,
                
            };
        }

        public ReaderModel ToShortDto()
        {
            return new ReaderModel
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email
            };
        }
    }
}
