using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ifst.API.ifst.Application.DTOs.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ifst.API.ifst.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthenticationController: ControllerBase
{
    private IConfiguration _configuration;
    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (loginDto.Username == "test" && loginDto.Password == "password")
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, loginDto.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretForKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        return Unauthorized();
    }
}