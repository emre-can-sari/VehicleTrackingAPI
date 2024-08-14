using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Business.Dtos;
using VehicleTracking.DataAccess;
using VehicleTracking.Entities.Entities;

namespace VehicleTracking.Business.Services;
public class JourneyService
{
    private readonly VehicleTrackingDbContext _context;

    public JourneyService(VehicleTrackingDbContext context)
    {
        _context = context;
    }

    public void CreateJourney(DtoJourney journeyDto)
    {
        var journey = new Journey
        {
            VehicleId = journeyDto.VehicleId,
            DriverId = journeyDto.DriverId,
            Destination = journeyDto.Destination
        };

        _context.Journeys.Add(journey);
        var driver = _context.Drivers.Find(journey.DriverId);
        driver.Journeys.Add(journey);
        _context.SaveChanges();
    }

    public Journey GetJourneyById(int id)
    {
        var journey = _context.Journeys.Find(id);
        if (journey == null)
        {
            return null;
        }

        return journey;
    }

    public IEnumerable<Journey> GetAllJourneys()
    {
        return _context.Journeys.ToList();
    }

    public void UpdateJourney(int id, DtoJourney journeyDto)
    {
        var journey = _context.Journeys.Find(id);
        if (journey != null)
        {
            journey.VehicleId = journeyDto.VehicleId;
            journey.DriverId = journeyDto.DriverId;
            journey.Destination = journeyDto.Destination;

            _context.Journeys.Update(journey);
            _context.SaveChanges();
        }
    }

    public void DeleteJourney(int id)
    {
        var journey = _context.Journeys.Find(id);
        if (journey != null)
        {
            var driver = _context.Drivers.Find(journey.DriverId);
            driver.Journeys.Remove(journey);
            _context.Journeys.Remove(journey);
            _context.SaveChanges();
        }
    }

    public void StartJourney(int journeyId)
    {
        var journey = _context.Journeys.Find(journeyId);
        if (journey != null)
        {
            journey.IsStarted = true;
            _context.SaveChanges();
        }
    }

    public void CompleteJourney(int journeyId)
    {
        var journey = _context.Journeys.Find(journeyId);
        if (journey != null)
        {
            journey.IsDelivered = true;
            journey.DeliveryTime = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
