using System.Collections.Generic;
using System.Linq;
using VehicleTracking.DataAccess;
using VehicleTracking.Entities.Entities;
using VehicleTracking.Business.Dtos;

namespace VehicleTracking.Business.Services
{
    public class DriverService
    {
        private readonly VehicleTrackingDbContext _context;

        public DriverService(VehicleTrackingDbContext context)
        {
            _context = context;
        }

        public Driver CreateDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return driver;
        }

        public Driver GetDriverById(int id)
        {
            return _context.Drivers.Find(id);
        }


        public IEnumerable<DtoDriver> GetAllDrivers()
        {
            return _context.Drivers.Select(d => new DtoDriver
            {
                Name = d.Name,
                LicenseNumber = d.LicenseNumber
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
