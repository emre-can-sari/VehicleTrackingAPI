using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VehicleTracking.Business.Dtos;
using VehicleTracking.Entities.Entities;
using global::VehicleTracking.Business.Dtos;
using global::VehicleTracking.DataAccess;
using global::VehicleTracking.Entities.Entities;

namespace VehicleTracking.Business.Services
{
    public class UserService
    {
        private readonly VehicleTrackingDbContext _context;
        private readonly string _jwtSecret = "RLXPCD8fqnLXhpPo2OpZ5bGSGkkWRQ1z";

        public UserService(VehicleTrackingDbContext context)
        {
            _context = context;
        }

        public void Register(UserDto userDto)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var user = new User
            {
                UserName = userDto.UserName,
                Password = hashedPassword,
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        
        public UserResponseDto Login(UserDto UserDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == UserDto.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(UserDto.Password, user.Password))
            {
                return null;
            }

            var token = GenerateJwtToken(user);

            return new UserResponseDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = token
            };
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    public UserDto GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return null;

            return new UserDto
            {
                UserName = user.UserName,
                Password = user.Password,
            };
        }
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}
