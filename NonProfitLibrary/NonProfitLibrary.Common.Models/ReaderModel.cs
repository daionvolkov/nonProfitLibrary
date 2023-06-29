using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NonProfitLibrary.Common.Models
{
    public class ReaderModel : CommonModel
    {
        public DateTime RegistrationDate { get; set; }
        public List<int>? TakenBooksId { get; set; }
        public List<int>? OrderBooksId { get; set; }

        public ReaderModel() { }

        public ReaderModel(string firstName, string lastName, string email, 
            string password, string phone, string birthDate,  
            DateTime registrationDate, List<int>? takenBooksId = null, List<int>? orderBooksId = null)
        {
            FirstName = firstName; 
            LastName = lastName;
            Email = email;
            Password = password; 
            Phone = phone;
            BirthDate = birthDate;
            RegistrationDate = registrationDate;
            TakenBooksId = takenBooksId;
            OrderBooksId = orderBooksId;
        }
    }
}
