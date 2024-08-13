using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTracking.Business.Dtos;

public class DtoJourney
{
    public int VehicleId { get; set; }
    public int DriverId { get; set; }
    public string Destination { get; set; }
}
