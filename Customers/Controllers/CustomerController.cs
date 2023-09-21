using Customers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly Customer[] Customer = new Customer[]
        {
          new Customer{ Id = 1, FullName = "Иванов Иван Иванвич", BankAccountId = 2},
          new Customer{ Id = 2, FullName = "Иванов Иван Степанович", BankAccountId = 1},
          new Customer{ Id = 3, FullName = "Иванов Иван Фомич", BankAccountId = 3},
          new Customer{ Id = 4, FullName = "Иванов Иван Кузьмич", BankAccountId = 4},
        };

        [HttpGet]
        public ICollection<Customer> Get()
        {
            return Customer;
        }
    }
}
