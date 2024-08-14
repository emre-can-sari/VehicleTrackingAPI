using System.Collections.Generic;
using System.Linq;
using VehicleTracking.DataAccess;
using VehicleTracking.Entities.Entities;
using VehicleTracking.Business.Dtos;
using Microsoft.EntityFrameworkCore;

namespace VehicleTracking.Business.Services
{
    public class DriverService
    {
        private readonly VehicleTrackingDbContext _context;

        public DriverService(VehicleTrackingDbContext context)
        {
            _context = context;
        }

        public Driver CreateDriver(DtoCreatedDriver dtoDriver)
        {
            Driver driver = new Driver { Name = dtoDriver.Name, LicenseNumber = dtoDriver.LicenseNumber};
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return driver;
        }

        public Driver GetDriverById(int id)
        {
            return _context.Drivers
                   .Include(d => d.Journeys)
                   .FirstOrDefault(d => d.Id == id);
        }


        public IEnumerable<DtoDriver> GetAllDrivers()
        {
            return _context.Drivers.Select(d => new DtoDriver
            {
                Name = d.Name,
                LicenseNumber = d.LicenseNumber,
                Journeys = d.Journeys,
                
            }).ToList();
        }

        public void UpdateDriver(int id, DtoDriver dtoDriver)
        {
            var driver = _context.Drivers.Find(id);
            if (driver == null)
            {
                return;
            }

            driver.Name = dtoDriver.Name;
            driver.LicenseNumber = dtoDriver.LicenseNumber;

            _context.SaveChanges();
        }

        public void DeleteDriver(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver == null)
            {
                return;
            }

            _context.Drivers.Remove(driver);
            _context.SaveChanges();
        }
    }
}
