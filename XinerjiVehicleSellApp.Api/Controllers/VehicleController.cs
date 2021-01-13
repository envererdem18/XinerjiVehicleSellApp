using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XinerjiVehicleSellApp.Model.Entities;
using XinerjiVehicleSellApp.Service.Abstract;

namespace XinerjiVehicleSellApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("GetVehicleList")]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _vehicleService.getAll();
            return Ok(vehicles);
        }

        [HttpGet("GetVehicle/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehicle = await _vehicleService.Get(id);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            return NotFound("Vehicle not not found");
        }

        [HttpPost("AddVehicle")]
        public async Task<IActionResult> Add([FromBody] Vehicle vehicle)
        {
            return Ok(await _vehicleService.Add(vehicle));
        }

        [HttpPut("UpdateVehicle")]
        public async Task<IActionResult> Update(Vehicle vehicle)
        {
            return Ok(await _vehicleService.Update(vehicle));
        }

        [HttpDelete("RemoveVehicle/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _vehicleService.Remove(id);
            return Ok(GetAll());
        }
    }
}
