using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Business.Dtos;
using VehicleTracking.DataAccess;
using VehicleTracking.Entities.Entities;

namespace VehicleTracking.Business.Services;

public class VehicleService
{
    private readonly VehicleTrackingDbContext _context;

    public VehicleService(VehicleTrackingDbContext context)
    {
        _context = context;
    }

    public Vehicle GetVehicleById(int id)
    {
        return _context.Vehicles.Find(id);
    }

    public List<Vehicle> GetAllVehicles()
    {
        return _context.Vehicles.ToList();
    }

    public void AddVehicle(DtoVehicle dtoVehicle)
    {
        Vehicle vehicle = new Vehicle{ LicensePlate = dtoVehicle.LicensePlate, Model = dtoVehicle.Model };
        _context.Vehicles.Add(vehicle);
        _context.SaveChanges();
    }

    public void UpdateVehicle(int id, DtoVehicle dtoVehicle)
    {

        var vehicle = _context.Vehicles.Find(id);
        if (vehicle != null)
        {
            vehicle.LicensePlate = dtoVehicle.LicensePlate;
            vehicle.Model = dtoVehicle.Model;

            _context.SaveChanges();
        }
    }


    public void DeleteVehicle(int id)
    {
        var vehicle = _context.Vehicles.Find(id);
        if (vehicle != null)
        {
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
        }
    }
}
