using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonProfitLibrary.Common.Models
{
    public class EmployeeModel : CommonModel
    {
        public EmployeePosition Position { get; set; }
        public EmployeeModel()
        {
        }

        public EmployeeModel(string firstName, string lastName, string email,
            string password, string phone, string birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
            BirthDate = birthDate;
            
        }
    }
}
