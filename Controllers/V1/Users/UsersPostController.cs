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
        if (userDTO == null || string.IsNullOrEmpty(userDTO.Email) || string.IsNullOrEmpty(userDTO.Password) || string.IsNullOrEmpty(userDTO.Name)|| string.IsNullOrEmpty(userDTO.LastName)|| string.IsNullOrEmpty(userDTO.Category)|| string.IsNullOrEmpty(userDTO.Abilities))
        {
            return BadRequest(ManageResponse.ErrorBadRequest());
        }

        // Create the qualification before create user with DTO properties.

        var qualification = new Qualification
        {
            Count = 0,
            AccumulatorAdition = 0
        };

        _dbContext.Qualifications.Add(qualification);
        _dbContext.SaveChanges();

        // Create the ability before create user with DTO propierties
        var abilities = new Ability
        {
            Category = userDTO.Category,
            Abilities = userDTO.Abilities
        };

        _dbContext.Abilities.Add(abilities);
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
            IdState = 1,
            IdRol = 2,
            IdQualification = qualification.Id,
            IdAbility = abilities.Id
        };

        

        // Create PasswordHasher<User> instance
        var passwordHasher = new PasswordHasher<User>();

        // Hash the password and assign it to the user's Password property
        user.Password = passwordHasher.HashPassword(user, userDTO.Password);

        // Save in database
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return Ok(ManageResponse.Successfull("User registered successfully."));
    }
}