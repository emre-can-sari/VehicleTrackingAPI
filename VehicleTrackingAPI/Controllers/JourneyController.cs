using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Business.Dtos;
using VehicleTracking.Business.Services;

namespace VehicleTrackingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JourneyController : ControllerBase
{
    private readonly JourneyService _journeyService;

    public JourneyController(JourneyService journeyService)
    {
        _journeyService = journeyService;
    }

    [HttpPost]
    public IActionResult CreateJourney([FromBody] DtoJourney journeyDto)
    {
        _journeyService.CreateJourney(journeyDto);
        return CreatedAtAction(nameof(GetJourneyById), new { id = journeyDto.VehicleId }, journeyDto);
    }

    [HttpGet("{id}")]
    public IActionResult GetJourneyById(int id)
    {
        var journey = _journeyService.GetJourneyById(id);
        if (journey == null)
        {
            return NotFound();
        }
        return Ok(journey);
    }

    [HttpGet]
    public IActionResult GetAllJourneys()
    {
        var journeys = _journeyService.GetAllJourneys();
        return Ok(journeys);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateJourney(int id, [FromBody] DtoJourney journeyDto)
    {
        _journeyService.UpdateJourney(id, journeyDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteJourney(int id)
    {
        _journeyService.DeleteJourney(id);
        return NoContent();
    }

    [HttpPost("{id}/start")]
    public IActionResult StartJourney(int id)
    {
        _journeyService.StartJourney(id);
        return NoContent();
    }

    [HttpPost("{id}/complete")]
    public IActionResult CompleteJourney(int id)
    {
        _journeyService.CompleteJourney(id);
        return NoContent();
    }
}
