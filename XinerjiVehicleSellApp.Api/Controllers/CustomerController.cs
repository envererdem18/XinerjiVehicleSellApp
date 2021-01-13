using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XinerjiVehicleSellApp.Api.Auth;
using XinerjiVehicleSellApp.Model.Entities;
using XinerjiVehicleSellApp.Service.Abstract;

namespace XinerjiVehicleSellApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public CustomerController(ICustomerService customerService, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _customerService = customerService;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet("GetCustomerList")]
        public async Task<IActionResult> GetAll()
        {
            var customers =  await _customerService.getAll();
            return Ok(customers);
        }

        [HttpGet("GetCustomer/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.Get(id);
            if(customer != null)
            {
                return Ok(customer);
            }
            return NotFound("Customer not not found");
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> Add([FromBody]Customer customer)
        {
            return Ok(await _customerService.Add(customer));
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> Update(Customer customer)
        {
            return Ok(await _customerService.Update(customer));
        }

        [HttpDelete("RemoveCustomer/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _customerService.Remove(id);
            return Ok(GetAll());
        }

        [HttpPost("GetVehiclesOfAUser")]
        public async Task<IActionResult> GetVehiclesOfAUser(int id)
        {
            return Ok(await _customerService.GetVehiclesOfACustomer(id));
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] Customer customer)
        {
           var token = _jwtAuthenticationManager.Authenticate(customer.FullName, customer.Password);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

    }
}
