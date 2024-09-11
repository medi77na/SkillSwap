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

    //Constructor
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

        var qualification = new Qualification{
            Count = userDTO.Count = 0,
            AccumulatorAdition = userDTO.AccumulatorAdition = 0
        };

        _dbContext.Qualifications.Add(qualification);
        _dbContext.SaveChanges();

        // Create the User instance with the DTO properties.
        var user = new User
        {
            Email = userDTO.Email,
            Password = userDTO.Password,
            Name = userDTO.Name,
            LastName = userDTO.LastName,
            Birthdate = userDTO.Birthdate,
            Description = userDTO.Description,
            JobTitle = userDTO.JobTitle,
            UrlLinkedin = userDTO.UrlLinkedin,
            UrlGithub = userDTO.UrlGithub,
            UrlBehance = userDTO.UrlBehance,
            UrlImage = userDTO.UrlImage,
            PhoneNumber = userDTO.PhoneNumber,
            IdState = userDTO.IdState,
            IdRol = userDTO.IdRol,
            IdQualification = qualification.Id
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
    public IActionResult Login([FromBody] AuthDTO userLoginPostDTO)
    {
        // Check if the request body or essential fields (Email and Password) are null or empty.
        if (userLoginPostDTO == null || string.IsNullOrEmpty(userLoginPostDTO.Email) || string.IsNullOrEmpty(userLoginPostDTO.Password))
        {
            return BadRequest("Invalid email or password.");
        }

        // Look for a user in the database with the provided email.
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == userLoginPostDTO.Email);
        if (user == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        // Verify the password using the password hasher.
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, userLoginPostDTO.Password);
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            return Unauthorized("Invalid email or password.");
        }

        // Generate a JWT token for the authenticated user.
        var token = GenerateJwtToken(user);

        return Ok(new { 
            Token = token,
            UserId = user.Id,
            RoleId = user.IdRol
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