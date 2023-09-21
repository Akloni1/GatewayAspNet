using Microsoft.AspNetCore.Mvc;

namespace GatewayService.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public GatewayController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient() ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        [HttpGet]
        public async Task<IActionResult> BankAccounts()
        {
           return await ProxyTo("https://localhost:5001/BankAccount");
        }
           
        [HttpGet]
        public async Task<IActionResult> Customers()
        {
            return await ProxyTo("https://localhost:5002/Customer");
        }

        [HttpGet]
        public async Task<IActionResult> CustomersWithBankAccounts()
        {
            return await ProxyTo("https://localhost:5003/CustomersWithBankAccount");
        }

        private async Task<ContentResult> ProxyTo(string url)
        {
           return Content(await _httpClient.GetStringAsync(url));
        }    
    }
}
