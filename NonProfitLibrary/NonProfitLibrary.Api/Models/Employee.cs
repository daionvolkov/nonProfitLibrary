using Microsoft.AspNetCore.Mvc.Rendering;
using NonProfitLibrary.Api.Models.Abstractions;
using NonProfitLibrary.Common.Models;

namespace NonProfitLibrary.Api.Models
{
    public class Employee: CommonObject
    {
        public int Id { get; set; }
        public EmployeePosition Position { get; set; }

       public Employee()
        {
        }

        public Employee(EmployeeModel employeeModel) : base(employeeModel)
        {
            FirstName = employeeModel.FirstName;
            LastName = employeeModel.LastName;
            Email = employeeModel.Email;
            Password = employeeModel.Password;
            Phone = employeeModel.Phone;
            BirthDate = employeeModel.BirthDate;
            CreationDate = DateTime.Now;
            Position = employeeModel.Position;
        }

        public EmployeeModel ToDto()
        {
            return new EmployeeModel
            {
                Id = this.Id, 
                FirstName = this.FirstName, 
                LastName = this.LastName, 
                Email = this.Email, 
                Password = this.Password, 
                Phone = this.Phone,
                BirthDate = this.BirthDate,
                CreationDate = this.CreationDate,
                Position = this.Position
            };
        }
    }
}
