using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarApp.BusinessLogic.Interfaces;
using CarApp.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CarApp.BusinessLogic.Services;

public class AuthService : IAuthService
{
    private IConfiguration _configuration;
    private readonly CarAppContext _carAppContext;
    
    public AuthService(IConfiguration configuration, CarAppContext carAppContext)
    {
        _configuration = configuration;
        _carAppContext = carAppContext;
    }
    
    public string Post(User _user)
    {
        var user = GetUser(_user.Email, _user.Password);

        if (user != null)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)),
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.Name),
                new Claim("Email", user.Email),
                new Claim("Password", user.Password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        return null;
    }

    public User GetUser(string email, string password)
    {
        return _carAppContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
    }
}