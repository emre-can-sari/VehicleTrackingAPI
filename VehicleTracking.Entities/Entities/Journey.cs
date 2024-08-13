using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTracking.Entities.Entities;

public class Journey
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public int DriverId { get; set; }
    public string Destination { get; set; } 
    public bool IsStarted { get; set; } = false; 
    public bool IsDelivered { get; set; } = false; 
    public DateTime? DeliveryTime { get; set; } 
}