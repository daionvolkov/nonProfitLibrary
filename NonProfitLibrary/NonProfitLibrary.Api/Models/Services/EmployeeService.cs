using NonProfitLibrary.Api.Models.Abstractions;
using NonProfitLibrary.Common.Models;
using System.Security.Claims;
using System.Text;

namespace NonProfitLibrary.Api.Models.Services
{
    public class EmployeeService : AbstractionService, ICommonService<EmployeeModel> 
    { 
    
       private ApplicationContext _db;
        public EmployeeService(ApplicationContext db)
        {
            _db = db;
        }
        public Tuple<string, string> GetUserLoginPassFromBasicAuth(HttpRequest request)
        {
            string userName = "";
            string userPass = "";
            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string encodedUserNamePass = authHeader.Replace("Basic ", "");
                var encoding = Encoding.GetEncoding("iso-8859-1");

                string[] namePassArray = encoding.GetString(Convert.FromBase64String(encodedUserNamePass)).Split(':');
                userName = namePassArray[0];
                userPass = namePassArray[1];
            }
            return new Tuple<string, string>(userName, userPass);
        }

        public Employee GetEmployee(string login, string password)
        {
            Employee employee = _db.Employee.FirstOrDefault(u => u.Email == login && u.Password == password) ?? new Employee();
            return employee;
        }

        public Employee GetEmployee(string login)
        {
            var employee = _db.Employee.FirstOrDefault(u => u.Email == login) ?? new Employee();
            return employee;
        }

        public ClaimsIdentity GetIdentity(string username, string password)
        {
            Employee currentEmployee = GetEmployee(username, password);
            if (currentEmployee != null)
            {
                _db.Employee.Update(currentEmployee);
                _db.SaveChanges();

                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, currentEmployee.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, currentEmployee.Position.ToString())

                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }

        public bool Create(EmployeeModel model)
        {
            bool result = DoAction(delegate ()
            {
                Employee employee = new Employee(model);
                _db.Employee.Add(employee);
                _db.SaveChanges();
            });
            return result;
        }

        public bool Delete(int id)
        {
            Employee employee = _db.Employee.FirstOrDefault(u => u.Id == id) ?? new Employee();
            if (employee != null)
            {
                return DoAction(delegate ()
                {
                    _db.Employee.Remove(employee);
                    _db.SaveChanges();
                });
            }
            return false;
        }

        public bool Update(int id, EmployeeModel model)
        {
            Employee employee = _db.Employee.FirstOrDefault(u => u.Id == id) ?? new Employee();
            if (employee != null) { }
            {
                return DoAction(delegate ()
                {
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.Password = model.Password;
                    employee.Phone = model.Phone;
                    employee.Email = model.Email;
                    _db.Employee.Update(employee);
                    _db.SaveChanges();
                });
            }
        }
    }
}
