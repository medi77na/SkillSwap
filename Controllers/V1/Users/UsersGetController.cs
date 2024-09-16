using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Dtos.User;
using SkillSwap.Models;

namespace SkillSwap.Controllers.V1.Users;

[ApiController]
[Route("api/[controller]")]
public class UsersGetController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public UsersGetController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// GENERAL INFORMATION
    /// </summary>
    /// <remarks>
    /// Obtain general information from system users
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        // Obtain the users from the database and project only the desired fields.
        var users = await _dbContext.Users
            .Select(user => new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                JobTitle = user.JobTitle,
                Description = user.Description,
                Birthdate = user.Birthdate,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                AbilityCategory = user.Ability != null ? user.Ability.Category : "No abilities",
                UrlLinkedin = user.UrlLinkedin,
                UrlGithub = user.UrlGithub,
                UrlBehance = user.UrlBehance,
                RoleName = user.IdRol != null ? user.IdRolNavigation.Name : "No role" 
            })
            .ToListAsync();

        return Ok(users);
    }
}