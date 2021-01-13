using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XinerjiVehicleSellApp.Service.Abstract;

namespace XinerjiVehicleSellApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        private readonly ISellService _sellService;
        public SellController(ISellService sellService)
        {
            _sellService = sellService;
        }

        [HttpPost("Sell")]
        public async Task<IActionResult> Sell(int id, int customerId, int vehicleId)
        {
            return Ok(await _sellService.SellVehicleToCustomer(id,customerId,vehicleId));
        }
    }
}
