using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Business.Dtos;
using VehicleTracking.Business.Services;
using VehicleTracking.DataAccess;
using VehicleTracking.Entities.Entities;

namespace VehicleTrackingAPI.Controllers;
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly VehicleService _vehicleService;

    public VehicleController(VehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpPost]
    [Route("api/vehicles")]
    public IActionResult AddVehicle([FromBody] DtoVehicle vehicle)
    {

        _vehicleService.AddVehicle(vehicle);
        return Ok(vehicle);
    }

    [HttpPut]
    [Route("api/vehicles/{id}")]
    public IActionResult UpdateVehicle(int id, [FromBody] DtoVehicle updatedVehicle)
    {
        var vehicle = _vehicleService.GetVehicleById(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _vehicleService.UpdateVehicle(id, updatedVehicle);
        return NoContent();
    }

    [HttpDelete]
    [Route("api/vehicles/{id}")]
    public IActionResult DeleteVehicle(int id)
    {
        var vehicle = _vehicleService.GetVehicleById(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _vehicleService.DeleteVehicle(id);
        return NoContent();
    }

    [HttpGet]
    [Route("api/vehicles/{id}")]
    public IActionResult GetVehicleById(int id)
    {
        var vehicle = _vehicleService.GetVehicleById(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }

    [HttpGet]
    [Route("api/vehicles")]
    public IActionResult GetAllVehicles()
    {
        var vehicles = _vehicleService.GetAllVehicles();
        return Ok(vehicles);
    }
}