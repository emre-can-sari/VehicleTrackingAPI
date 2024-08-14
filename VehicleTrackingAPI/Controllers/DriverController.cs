using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Business.Dtos;
using VehicleTracking.Business.Services;
using VehicleTracking.Entities.Entities;

namespace VehicleTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriverController(DriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        public IActionResult CreateDriver([FromBody] DtoCreatedDriver dtoDriver)
        {
            if (dtoDriver == null)
            {
                return BadRequest("Driver data is required.");
            }


            var driver = _driverService.CreateDriver(dtoDriver);

            var createdDriver = _driverService.GetDriverById(driver.Id);

            if (createdDriver == null)
            {
                return BadRequest("Failed to create driver.");
            }

            return CreatedAtAction(nameof(GetDriverById), new { id = driver.Id }, createdDriver);
        }

        [HttpGet("{id}")]
        public IActionResult GetDriverById(int id)
        {
            var driver = _driverService.GetDriverById(id);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpGet]
        public IActionResult GetAllDrivers()
        {
            var drivers = _driverService.GetAllDrivers();
            return Ok(drivers);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDriver(int id, [FromBody] DtoDriver dtoDriver)
        {
            if (dtoDriver == null)
            {
                return BadRequest("Driver data is required.");
            }

            _driverService.UpdateDriver(id, dtoDriver);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(int id)
        {
            var driver = _driverService.GetDriverById(id);
            if (driver == null)
            {
                return NotFound();
            }

            _driverService.DeleteDriver(id);
            return NoContent();
        }
    }
}
