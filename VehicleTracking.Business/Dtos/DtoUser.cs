using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTracking.Business.Dtos;
public class UserDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class UserResponseDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
}