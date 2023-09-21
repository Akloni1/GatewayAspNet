using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Text.Json;

namespace Aggregator.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class CustomerBankAccountController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public CustomerBankAccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient() ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        [HttpGet]
        public async Task<IActionResult> CustomersWithBankAccount()
        {
            var bankAccounts = await BankAccounts();
            var customers = await Customers();
            var res = customers.Join(bankAccounts,
                c => c.bankAccountId,
                b => b.id,
                (c, b) => new { c.id, c.fullName, b.amountOfMoney}
                );
            return Ok(res);
        }
        private async Task<ICollection<BankAccount>> BankAccounts()
        {
            var response = _httpClient.GetStringAsync("https://localhost:5001/BankAccount").Result;
            var bankAccount = JsonSerializer.Deserialize<List<BankAccount>>(response);
            return bankAccount;
           
        }

        private async Task<ICollection<Customer>> Customers()
        {
            var response = _httpClient.GetStringAsync("https://localhost:5002/Customer").Result;
            var customers = JsonSerializer.Deserialize<List<Customer>>(response);
            return customers;
        }
    }

    public class BankAccount
    {
        public int id { get; set; }
        public decimal amountOfMoney { get; set; }
        public string currencyCode { get; set; }
    }
    public class Customer
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public int bankAccountId { get; set; }
    }
}
