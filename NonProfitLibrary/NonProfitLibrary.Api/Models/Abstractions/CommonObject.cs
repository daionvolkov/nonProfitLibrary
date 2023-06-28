using NonProfitLibrary.Common.Models;

namespace NonProfitLibrary.Api.Models.Abstractions
{
    public class CommonObject
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? BirthDate { get; set; }
        public DateTime CreationDate { get; set; }

        public CommonObject()
        {
            CreationDate = DateTime.Now;
        }

        public CommonObject(CommonModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            Email = model.Email;
            Password = model.Password;
            Phone = model.Phone;
            BirthDate = model.BirthDate;
            CreationDate = DateTime.Now;
        }
    }
}
