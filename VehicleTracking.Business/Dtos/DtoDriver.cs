using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Entities.Entities;

namespace VehicleTracking.Business.Dtos;

public class DtoDriver
{
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public List<Journey> Journeys { get; set; }
}
public class DtoCreatedDriver
{
    public string Name { get; set; }
    public string LicenseNumber { get; set; }

}
