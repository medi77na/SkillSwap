using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkillSwap.Dtos.User;
using SkillSwap.Models;

namespace SkillSwap.Controllers.V1.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher<User> _passwordHasher;

    //Constructor
    public AuthController(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
        _passwordHasher = new PasswordHasher<User>();
    }

    // User Login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthDTO userLoginPostDTO)
    {
        // Check if the request body or essential fields (Email and Password) are null or empty.
        if (userLoginPostDTO == null || string.IsNullOrEmpty(userLoginPostDTO.Email) || string.IsNullOrEmpty(userLoginPostDTO.Password))
        {
            return BadRequest(ManageResponse.ErrorBadRequest());
        }

        // Look for a user in the database with the provided email.
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userLoginPostDTO.Email);
        if (user == null)
        {
            return Unauthorized(ManageResponse.ErrorUnauthorized());
        }

        // Verify the password using the password hasher.
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, userLoginPostDTO.Password);
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            return Unauthorized("Invalid email or password.");
        }

        // Generate a JWT token for the authenticated user.
        var token = GenerateJwtToken(user);

        return Ok(new
        {
            message = "Success",
            data = new
            {
                id = user.Id,
                role = user.IdRol,
                email = user.Email,
                token = token
            }
        });
    }

    // Generate JWT token for authenticated users
    private string GenerateJwtToken(User user)
    {
        // Create a security key using the secret key from configuration.
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_KEY"]));

        // Create signing credentials using the security key and HMAC-SHA256 algorithm.
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Define the claims to include in the token, such as the user's email and a unique identifier (JTI).
        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        // Build the JWT token with the defined issuer, audience, claims, expiration time, and signing credentials.
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT_ISSUER"],
            audience: _configuration["JWT_AUDIENCE"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JWT_EXPIREMINUTES"])),
            signingCredentials: credentials                    // Signing credentials for token security
        );

        // Return the JWT token as a string.
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}