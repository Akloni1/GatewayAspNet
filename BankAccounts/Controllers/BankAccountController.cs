using BankAccounts.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAccounts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        private static readonly BankAccount[] BankAccount = new BankAccount[]
        {
            new BankAccount{ Id = 1, AmountOfMoney = 20000, CurrencyCode = "RUB"},
            new BankAccount{ Id = 2, AmountOfMoney = 30000, CurrencyCode = "RUB"},
            new BankAccount{ Id = 3, AmountOfMoney = 40000, CurrencyCode = "RUB"},
            new BankAccount{ Id = 4, AmountOfMoney = 50000, CurrencyCode = "RUB"},
        };

        [HttpGet]
        public ICollection<BankAccount> Get()
        {
            return BankAccount;
        }
    }
}
