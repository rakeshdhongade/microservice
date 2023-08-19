using Microsoft.AspNetCore.Mvc;
using sampleWebAPI.src.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sampleWebAPI.src.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private ILogger _log { get; }
        private IVehicleRepository _vehicleRepository { get; }

        public VehicleController( IVehicleRepository vehicleRepository)
        {
            //_log = log;
            _vehicleRepository = vehicleRepository;
        }
        // GET: api/<VehicleController>
        [HttpGet]
        public async Task<IEnumerable<VehicleDto>> GetAsyc()
        {
            return await _vehicleRepository.GetAllVehicleAsync();
        }

        // GET api/<VehicleController>/5
        [HttpGet("{number}")]
        public async Task<VehicleDto> GetAsyc(string number)
        {
            return await _vehicleRepository.GetVehicleAsync(number);
        }

        // POST api/<VehicleController>
        [HttpPost]
        public async void Post([FromBody] VehicleDto vehicle)
        {
            await _vehicleRepository.AddVehicleAsync(vehicle);
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{guid}")]
        public async Task Put(Guid guid, [FromBody] VehicleDto vehicle)
        {
            await _vehicleRepository.UpdateVechicleAsync(guid, vehicle);
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{guid}")]
        public async Task Delete(Guid guid)
        {
            await _vehicleRepository.DeleteVechicleAsync(guid);
        }
    }
}
