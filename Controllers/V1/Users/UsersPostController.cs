using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SkillSwap.Dtos.User;
using SkillSwap.Models;

namespace SkillSwap.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class UsersPostController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher<User> _passwordHasher;

    public UsersPostController(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
        _passwordHasher = new PasswordHasher<User>();
    }

    // User Creation
    [HttpPost]
    public IActionResult Register([FromBody] UserPostDTO userDTO)
    {
        if (userDTO == null || string.IsNullOrEmpty(userDTO.Email) || string.IsNullOrEmpty(userDTO.Password))
        {
            return BadRequest("Invalid email or password.");
        }

        // Create the User instance with the DTO properties.
        var user = new User
        {
            Email = userDTO.Email,
            Name = userDTO.Name,
            LastName = userDTO.LastName,
            Birthdate = userDTO.Birthdate,
            Description = userDTO.Description,
            JobTitle = userDTO.JobTitle,
            UrlLinkedin = userDTO.UrlLinkedin,
            UrlImage = userDTO.UrlImage,
            PhoneNumber = userDTO.PhoneNumber,
            IdState = userDTO.IdState,
            IdRol = userDTO.IdRol
        };

        // Create PasswordHasher<User> instance 
        var passwordHasher = new PasswordHasher<User>();

        // Hash the password and assign it to the user's Password property
        user.Password = passwordHasher.HashPassword(user, userDTO.Password);

        // Save in database
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return Ok("User registered successfully.");
    }

    // User Login
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginPostDTO userLoginPostDTO)
    {
        if (userLoginPostDTO == null || string.IsNullOrEmpty(userLoginPostDTO.Email) || string.IsNullOrEmpty(userLoginPostDTO.Password))
        {
            return BadRequest("Invalid email or password.");
        }

        var user = _dbContext.Users.FirstOrDefault(u => u.Email == userLoginPostDTO.Email);
        if (user == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        // Verify the password
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, userLoginPostDTO.Password);
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            return Unauthorized("Invalid email or password.");
        }

        // Generate JWT token
        var token = GenerateJwtToken(user);

        return Ok(new { Token = token });
    }

    // Generate JWT token for authenticated users
    private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_KEY"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT_ISSUER"],
            audience: _configuration["JWT_AUDIENCE"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JWT_EXPIREMINUTES"])),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}